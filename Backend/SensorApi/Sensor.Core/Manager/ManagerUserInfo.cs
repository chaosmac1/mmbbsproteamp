using Dapper;
using LamLibAllOver;
using Npgsql;
using Sensor.Repository.Database.Query;

namespace Sensor.Core.Manager; 

public static class ManagerUserInfo {
    public static async Task<Option<Entity.UserInfo>> FindByIdAsync(NpgsqlConnection db, UserId id) {
        return (await QueryUserInfo.FindByIdAsync(db, id.Value)).Map(Parse.ToDomainUserInfo);
    }

    public static async Task<Option<Entity.UserInfo>> FindByUsernameAsync(NpgsqlConnection db, string username) {
        return (await QueryUserInfo.FindByUsernameAsync(db, username)).Map(Parse.ToDomainUserInfo);
    }

    public static async Task UpdateByIdAsync(NpgsqlConnection db, UserInfo userInfo) {
        await QueryUserInfo.UpdateByIdAsync(db, Parse.ToPocoUserInfo(userInfo));
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, UserId id) {
        await QueryUserInfo.DeleteByIdAsync(db, id.Value);
    }

    public static async Task<List<UserInfo>> GetAllAsync(NpgsqlConnection db) {
        return (await QueryUserInfo.GetAll(db)).Select(Parse.ToDomainUserInfo).AsList();
    }

    public static async Task InsertAsync(NpgsqlConnection db, UserInfo userInfo) {
        await QueryUserInfo.InsertAsync(db, Parse.ToPocoUserInfo(userInfo));
    }
    
    public static async Task<Option<UserInfo>> GetUserInfoIsTokenUserIsAdminAsync(NpgsqlConnection db, UserId userId) {
        var userInfo = await ManagerUserInfo.FindByIdAsync(db, userId );
        if (userInfo.IsNotSet() || !userInfo.Unwrap().IsAdmin) {
            return Option<UserInfo>.Empty;
        }

        return userInfo;
    }
}