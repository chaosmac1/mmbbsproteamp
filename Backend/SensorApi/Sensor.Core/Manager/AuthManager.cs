using LamLibAllOver;
using Npgsql;
using Sensor.Domain.ValueObject;


namespace Sensor.Core.Manager; 

public static class AuthManager {
    public static Option<(UserId UserId, UserToken Token)> WebLogin(NpgsqlConnection db, string username, string password) {
        throw new NotImplementedException(nameof(WebLogin));
    }

    public static Option<(IotId IotId, IotToken Jwt)> IotLogin(NpgsqlConnection db, string username, string password) {
        throw new NotImplementedException(nameof(IotLogin));
    }

    public static bool WebUpdate(NpgsqlConnection db, UserToken token) {
        throw new NotImplementedException(nameof(WebUpdate));
    }

    public static bool WebLogout(NpgsqlConnection db, UserToken token) {
        throw new NotImplementedException(nameof(WebLogout));
    }
}