using env = Sensor.Env.Env;
namespace Sensor.Log; 

internal static class Setting {
    public static string  Host     = env.DbIp;
    public static int     Port     = env.DbPort;
    public static string  Password = env.DbPassword;
    public static string  Username = env.DbUsername;
    public static string  Database = env.DbDatabase;
    public static bool    Pooling  = true;
    public static int     MaxPoolSize = 10;
    public static int     MinPoolSize = 1;
    public static int     Timeout = 1024;
}