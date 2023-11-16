using LamLibAllOver;
using Npgsql;
using Sensor.Domain.ValueObject;

namespace Sensor.Core.Manager; 

public static class UserManager {
    public static bool UpdatePassword(NpgsqlConnection db, Guid userId, string oldPassword, string newPassword) {
        throw new NotImplementedException(nameof(UpdatePassword));
    }

    public static Option<UserId> CreateUser(NpgsqlConnection db, string username, string password) {
        throw new NotImplementedException(nameof(CreateUser));
    }
}