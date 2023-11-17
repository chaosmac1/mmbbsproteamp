using Microsoft.Extensions.Configuration;

namespace Sensor.Domain; 

public static class Env {
    public static readonly string JwtKey = GetEnvironmentVariableCheckNull("JWT_KEY"); 
    public static readonly string DbIp = GetEnvironmentVariableCheckNull("DB_IP"); 
    public static readonly int DbPort = int.Parse(GetEnvironmentVariableCheckNull("DB_PORT"));
    public static readonly string DbUsername = GetEnvironmentVariableCheckNull("DB_USERNAME");
    public static readonly string DbPassword = GetEnvironmentVariableCheckNull("DB_PASSWORD");
    
    private static IConfigurationRoot? Config { get; set; }

    private static IConfigurationRoot ReadConfig() {
        var config = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", true)
                     .AddEnvironmentVariables()
                     .Build();
        return config;
    }
    
    private static string GetEnvironmentVariableCheckNull(string name) {
        if (Config is null) {
            Config = ReadConfig();
        }
        return Config[name] ?? throw new NullReferenceException("EnvironmentVariable " + name);
    }
}