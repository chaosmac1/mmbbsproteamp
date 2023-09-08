using LamLibAllOver;
using Npgsql;
using SensorLib.Dto;

namespace SensorLib.Manager; 

public class CookieTokenManager {
    public static Task<Option<WebCookieDto>> GetCookieByTokenAsync(NpgsqlConnection db, Guid token) { }
}