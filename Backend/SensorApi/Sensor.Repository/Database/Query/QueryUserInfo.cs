using LamLibAllOver;
using Npgsql;
using Dapper;
using Sensor.Repository.Database.Poco;

namespace Sensor.Repository.Database.Query; 

public static class QueryUserInfo {
    public static async Task<Option<UserInfo>> FindByIdAsync(NpgsqlConnection db, Guid id) {
        return Option<UserInfo>.With(await db.QueryFirstOrDefaultAsync(@"
SELECT * 
FROM user_info
WHERE id = @id
", new { id = id }));
    }

    public static async Task<Option<UserInfo>> FindByUsernameAsync(NpgsqlConnection db, string username) {
        return Option<UserInfo>.With(await db.QueryFirstOrDefaultAsync(@"
SELECT * 
FROM user_info
WHERE username = @username
", new { username = username }));
    }

    public static async Task UpdateByIdAsync(NpgsqlConnection db, UserInfo userInfo) {
        await db.ExecuteAsync(sql: @"
UPDATE user_info SET username = @username AND password_hash = @password_hash and is_admin = @is_admin
WHERE id = @id 
", userInfo);
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, Guid id) {
        await db.ExecuteAsync(@"
DELETE FROM user_info WHERE id = @id
", new { id = id });
    }

    public static async Task Insert(NpgsqlConnection db, UserInfo userInfo) {
        
    }
}