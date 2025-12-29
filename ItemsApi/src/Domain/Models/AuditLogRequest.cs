namespace Domain.Models;

using System.Text.Json.Serialization;
using Domain;
using Domain.Enums;

public record AuditLogRequest
{
    [JsonPropertyName("event_type")]
    public AuditLogEventType EventType { get; set; }

    [JsonPropertyName("payload")]
    public Item Payload { get; set; }

    private AuditLogRequest(Item payload, AuditLogEventType eventType)
    {
        Payload = payload;
        EventType = eventType;
    }

    public static Result<AuditLogRequest> Create(Item payload, AuditLogEventType eventType)
    {
        return Result<AuditLogRequest>.Success(new AuditLogRequest(payload, eventType));
    }
}