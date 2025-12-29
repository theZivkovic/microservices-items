namespace Domain.Enums;

using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AuditLogEventType
{
    [JsonStringEnumMemberName("item.created")]
    ItemCreated,
    [JsonStringEnumMemberName("item.deleted")]
    ItemDeleted
}