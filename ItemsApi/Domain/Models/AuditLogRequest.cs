namespace Domain.Models;

using Domain;
using Domain.Enums;

public record AuditLogRequest
{
    public AuditLogEventType EventType;
    public Item Payload;

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