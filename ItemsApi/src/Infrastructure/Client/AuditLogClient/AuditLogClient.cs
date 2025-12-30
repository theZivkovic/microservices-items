
using Domain.Enums;
using Domain.Interfaces.Clients;
using Domain.Models;

using Polly;
using Polly.Retry;
using System.Net;

namespace Infrastructure.Client;

public class AuditLogClient(HttpClient httpClient) : IAuditLogClient
{
    public async Task AddItemEvent(AuditLogEventType eventType, Item item)
    {
        var pipeline = new ResiliencePipelineBuilder()
            .AddRetry(new RetryStrategyOptions
            {
                ShouldHandle = new PredicateBuilder()
                    .Handle<HttpRequestException>(ex => ex.StatusCode is HttpStatusCode code && ((int)code == 429 || (int)code >= 500)),
                MaxRetryAttempts = 4,
                Delay = TimeSpan.FromSeconds(1),
                BackoffType = DelayBackoffType.Exponential,
                UseJitter = true,
            })
            .Build();

        await pipeline.ExecuteAsync(async ct =>
                {
                    using var response = await httpClient.PostAsJsonAsync("/api/audit-logs", AuditLogRequest.Create(item, eventType).Value!, ct);
                    response.EnsureSuccessStatusCode();
                    return response;
                });
    }
}