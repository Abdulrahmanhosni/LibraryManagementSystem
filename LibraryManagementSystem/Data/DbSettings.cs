using Microsoft.Extensions.Configuration;

namespace LibraryManagementSystem.Data;

public static class DbSettings
{
    public static string ConnectionString { get; } = Load();

    private static string Load()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        return config.GetConnectionString("LibraryDb")!;
    }
}