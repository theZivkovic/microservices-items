namespace Presentation;

public class AppSettingsDatabase
{
    public required string Host { get; set; }
    public required string Port { get; set; }
    public required string User { get; set; }
    public required string Password { get; set; }
    public required string Database { get; set; }
}

public class AppSettingsAuditLogService
{

    public required string BaseUrl { get; set; }
}

public class AppSettings
{
    public required AppSettingsDatabase Database { get; set; }
    public required AppSettingsAuditLogService AuditLogService { get; set; }
}