using Npgsql;
using Sensor.Repository.Database.Poco;
using Dapper;
using LamLibAllOver;

namespace Sensor.Repository.Database.Query; 

public static class QueryIotDevice {
    public static async Task<List<IotDevice>> AllAsync(NpgsqlConnection db) {
        return (await db.QueryAsync<IotDevice>(@"
SELECT * 
FROM iot_device 
")).AsList();
    }
    public static async Task<Option<IotDevice>> FindByIdAsync(NpgsqlConnection db, Guid id) {
        return Option<IotDevice>.With(await db.QueryFirstOrDefaultAsync<IotDevice>(@"
SELECT * 
FROM iot_device 
WHERE id = @id
", new { id = id }));
    }
    
    public static async Task<Option<IotDevice>> FindByNameAsync(NpgsqlConnection db, string name) {
        return Option<IotDevice>.With(await db.QueryFirstOrDefaultAsync<IotDevice>(@"
SELECT * 
FROM iot_device 
WHERE name = @name
", new { name = name }));
    }
    
    public static async Task InsertIotDeviceAsync(NpgsqlConnection db, IotDevice value) {
        await db.ExecuteAsync(@"
INSERT INTO iot_device 
    (id, name, last_request, allowed_request) 
VALUES
    (@id, @name, @last_request, @allowed_request)
", new {
            id = value.id, 
            name = value.name, 
            last_request = value.last_request, 
            allowed_request = value.allowed_request
        });
    }
    
    public static async Task UpdateIotDeviceFindByIdAsync(NpgsqlConnection db, IotDevice value) {
        await db.ExecuteAsync(@"
Update iot_device SET name = @name and last_request = @last_request and allowed_request = @allowed_request
WHERE id = @id
", new {
            id = value.id, 
            name = value.name, 
            last_request = value.last_request, 
            allowed_request = value.allowed_request
        });
    }

    public static async Task DeleteByIdAsync(NpgsqlConnection db, Guid id) {
        await db.ExecuteAsync(@"
DELETE FROM iot_device WHERE id = @id
", new { id = id });
    }
}