namespace Infrastructure.Client;

using System.Text.Json;
using Domain.Enums;
using Domain.Interfaces.Clients;
using Domain.Models;

public class AuditLogClient(HttpClient httpClient) : IAuditLogClient
{
    public async Task AddItemEvent(AuditLogEventType eventType, Item item)
    {
        using var response = await httpClient.PostAsJsonAsync("/api/audit-logs", AuditLogRequest.Create(item, eventType));
        response.EnsureSuccessStatusCode();
    }
}