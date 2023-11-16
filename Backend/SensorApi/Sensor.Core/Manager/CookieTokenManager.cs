using LamLibAllOver;
using Npgsql;
using Sensor.Domain.Entities;

namespace Sensor.Core.Manager; 

public class CookieTokenManager {
    public static Task<Option<WebCookie>> GetCookieByTokenAsync(NpgsqlConnection db, string token) {
        throw new NotImplementedException(nameof(GetCookieByTokenAsync));
    }
}