using LamLibAllOver;
using Npgsql;
using Sensor.Core.Query;
using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;

namespace Sensor.Core.Manager; 

public static class ManagerUserCookie {
    public static async Task<Option<UserCookie>> GetByIdAsync(NpgsqlConnection db, UserToken userToken) {
        return (await QueryUserCookie.GetByIdAsync(db, userToken.Value))
            .Map(x => new UserCookie(new UserToken { Value = x.Id }) {
                    UserId = new UserId() { Value = x.UserId },
                    EndDateTime = x.EndDateTime
                }
            );
    }

    public static async Task UpdateAsync(NpgsqlConnection db, UserCookie userCookie) {
        await QueryUserCookie.UpdateAsync(db, new Db.Poco.UserCookie() {
            Id = userCookie.Id.Value,
            UserId = userCookie.UserId.Value,
            EndDateTime = userCookie.EndDateTime
        });
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, UserToken userToken) {
        await QueryUserCookie.DeleteByIdAsync(db, userToken.Value);
    }
}