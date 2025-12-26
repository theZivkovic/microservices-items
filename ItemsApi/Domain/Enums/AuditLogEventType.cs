namespace Domain.Enums;

using System.ComponentModel;

public enum AuditLogEventType
{
    [Description("item.created")]
    ItemCreated,
    [Description("item.deleted")]
    ItemDeleted
}