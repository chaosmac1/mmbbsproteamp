using LamLibAllOver;
using Npgsql;

namespace SensorLib.Manager; 

public static class UserManager {
    public static bool UpdatePassword(NpgsqlConnection db, Guid userId, string oldPassword, string newPassword) { }
    
    public static Option<Guid> CreateUser(NpgsqlConnection db, string username, string password) { }
}