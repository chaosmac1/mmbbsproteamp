using Dapper;
using LamLibAllOver;
using Npgsql;
using Sensor.Repository.Database.Poco;

namespace Sensor.Repository.Database.Query; 

public static class QueryUserCookie {
    public static async Task<Option<UserCookie>> GetByIdAsync(NpgsqlConnection db, string id) {
        return Option<UserCookie>.With(await db.QueryFirstOrDefaultAsync<UserCookie>(@"
SELECT * 
FROM user_cookie 
WHERE id = @id
", new { id = id }));
    }

    public static async Task<List<UserCookie>> GetByUserId(NpgsqlConnection db, Guid userId) {
        return (await db.QueryAsync<UserCookie>(@"
SELECT * 
FROM user_cookie
WHERE user_id = @user_id 
", new { user_id = userId })).AsList();
    }
    
    public static async Task UpdateFindByIdAsync(NpgsqlConnection db, UserCookie userCookie) {
        await db.ExecuteAsync(@"
UPDATE user_cookie 
SET end_datetime = @end_datetime AND user_id = @user_id
WHERE id = @id
", new {
            id = userCookie.id,
            end_datetime = userCookie.end_datetime,
            user_id = userCookie.user_id
        });
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, string id) {
        await db.ExecuteAsync(@"
DELETE FROM user_cookie 
WHERE id = @id
");
    }
}