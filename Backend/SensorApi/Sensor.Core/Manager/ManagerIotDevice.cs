using Dapper;
using LamLibAllOver;
using Npgsql;
using Sensor.Repository.Database.Query;

namespace Sensor.Core.Manager; 

public static class ManagerIotDevice {
    public static async Task<List<IotDevice>> AllAsync(NpgsqlConnection db) {
        return (await QueryIotDevice.AllAsync(db)).Select(Parse.ToDomainIotDevice).AsList();
    }
    public static async Task<Option<IotDevice>> FindByIdAsync(NpgsqlConnection db, IotId id) {
        return (await QueryIotDevice.FindByIdAsync(db, id.Value)).Map(Parse.ToDomainIotDevice);
    }
    
    public static async Task<Option<IotDevice>> FindByNameAsync(NpgsqlConnection db, string name) {
        return (await QueryIotDevice.FindByNameAsync(db, name)).Map(Parse.ToDomainIotDevice);
    }
    
    public static Task InsertIotDeviceAsync(NpgsqlConnection db, IotDevice value) {
        return QueryIotDevice.InsertIotDeviceAsync(db, Parse.ToPocoIotDevice(value));
    }
    
    public static Task UpdateIotDeviceFindByIdAsync(NpgsqlConnection db, IotDevice value) {
        return QueryIotDevice.UpdateIotDeviceFindByIdAsync(db, Parse.ToPocoIotDevice(value));
    }

    public static Task DeleteByIdAsync(NpgsqlConnection db, IotId id) {
        return QueryIotDevice.DeleteByIdAsync(db, id.Value);
    }
}