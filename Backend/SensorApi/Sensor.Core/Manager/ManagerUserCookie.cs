using LamLibAllOver;
using Npgsql;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database.Query;
using UserCookie = Sensor.Domain.Entity.UserCookie;

namespace Sensor.Core.Manager; 

public static class ManagerUserCookie {
    public static async Task<Option<Domain.Entity.UserCookie>> GetByIdAsync(NpgsqlConnection db, UserToken userToken) {
        return (await QueryUserCookie.GetByIdAsync(db, userToken.Value))
            .Map(x => new Domain.Entity.UserCookie(new UserToken { Value = x.id }) {
                    UserId = new UserId() { Value = x.user_id },
                    EndDateTime = x.end_datetime
                }
            );
    }

    public static async Task UpdateAsync(NpgsqlConnection db, UserCookie userCookie) {
        await QueryUserCookie.UpdateFindByIdAsync(db, new () {
            id = userCookie.Id.Value,
            user_id = userCookie.UserId.Value,
            end_datetime = userCookie.EndDateTime
        });
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, UserToken userToken) {
        await QueryUserCookie.DeleteByIdAsync(db, userToken.Value);
    }

    public static async Task InsertAsync(NpgsqlConnection db, UserCookie userCookie) {
        await QueryUserCookie.InsertAsync(db, Parse.ToPocoUserCookie(userCookie));
    }
}