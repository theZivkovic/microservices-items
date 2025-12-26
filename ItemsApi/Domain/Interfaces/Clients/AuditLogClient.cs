namespace Domain.Interfaces.Clients;

using Domain.Enums;
using Domain.Models;

public interface IAuditLogClient
{
    public Task AddItemEvent(AuditLogEventType eventType, Item item);
}