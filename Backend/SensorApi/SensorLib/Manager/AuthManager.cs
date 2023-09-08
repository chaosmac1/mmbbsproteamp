using LamLibAllOver;
using Microsoft.VisualBasic.CompilerServices;
using Npgsql;

namespace SensorLib.Manager; 

public static class AuthManager {
    public static Option<(Guid UserId, Guid Token)> WebLogin(NpgsqlConnection db, string username, string password) {
        
    }

    public static Option<(Guid IotId, string Jwt)> IotLogin(NpgsqlConnection db, string username, string password) {
        
    }
    
    public static bool WebUpdate(NpgsqlConnection db, Guid token) { } 
    public static bool WebLogout(NpgsqlConnection db, Guid token) { } 
}