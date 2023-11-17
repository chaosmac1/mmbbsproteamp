using LamLibAllOver;
using Npgsql;
using Sensor.Db.Poco;
namespace Sensor.Core.Query; 

public static class QueryUserCookie {
    public static async Task<Option<UserCookie>> GetByIdAsync(NpgsqlConnection db, string id) {
        throw new NotImplementedException(nameof(GetByIdAsync));
    }

    public static async Task UpdateAsync(NpgsqlConnection db, UserCookie userCookie) {
        throw new NotImplementedException(nameof(UpdateAsync));
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, string id) {
        throw new NotImplementedException(nameof(DeleteByIdAsync));
    }
}