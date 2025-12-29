public static class ConfigurationExtensions
{
    public static string ToNpSqlConnectionString(this IConfigurationSection dbSection)
    {
        return $"Host={dbSection["Host"]};Port={dbSection["Port"]};Database={dbSection["Database"]};Username={dbSection["User"]};Password={dbSection["Password"]}";
    }
}