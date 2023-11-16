using Microsoft.Extensions.Configuration;

namespace Sensor.Core; 

public class Env {
    public static readonly string DbIp = GetEnvironmentVariableCheckNull("DB_IP"); 
    public static readonly int DbPort = int.Parse(GetEnvironmentVariableCheckNull("DB_PORT"));
    public static readonly string DbUsername = GetEnvironmentVariableCheckNull("DB_USERNAME");
    public static readonly string DbPassword = GetEnvironmentVariableCheckNull("DB_PASSWORD");
    
    private Env() { }
    
    private static readonly IConfigurationRoot Config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true)
        .AddEnvironmentVariables()
        .Build();
    
    private static string GetEnvironmentVariableCheckNull(string name) {
        return Config[name] ?? throw new NullReferenceException("EnvironmentVariable " + name);
    }
}