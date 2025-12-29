namespace Domain.Enums;

using System.Text.Json.Serialization;

public enum AuditLogEventType
{
    [JsonStringEnumMemberName("item.created")]
    ItemCreated,
    [JsonStringEnumMemberName("item.deleted")]
    ItemDeleted
}