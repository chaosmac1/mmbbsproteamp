namespace Sensor.Db; 

public static class Setting {
    public static string  Host     = "127.0.0.1";
    public static int     Port     = 5432;
    public static string  Password = "postgres";
    public static string  Username = "postgres";
    public static string  Database = "database";
    public static bool    Pooling  = true;
    public static int     MaxPoolSize = 3000;
    public static int     MinPoolSize = 100;
    public static int     Timeout = 1024;
}