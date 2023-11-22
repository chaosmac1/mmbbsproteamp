using Sensor.Repository.Database.Poco;
using UserCookie = Sensor.Repository.Database.Poco.UserCookie;

namespace Sensor.Core; 

internal static class Parse {
    public static Sensor.Domain.Entity.IotDevice ToDomainIotDevice(Sensor.Repository.Database.Poco.IotDevice value) {
        return new Sensor.Domain.Entity.IotDevice(new IotId() { Value = value.id }) {
            Name = value.name,
            AllowedRequest = value.allowed_request,
            LastRequest = value.last_request
        };
    }
    
    public static Sensor.Repository.Database.Poco.IotDevice ToPocoIotDevice(Sensor.Domain.Entity.IotDevice value) {
        return new () {
            id = value.Id.Value,
            allowed_request = value.AllowedRequest,
            last_request = value.LastRequest,
            name = value.Name
        };
    }

    public static Sensor.Repository.Database.Poco.UserInfo ToPocoUserInfo(Sensor.Domain.Entity.UserInfo value) {
        return new Repository.Database.Poco.UserInfo() {
            id = value.Id.Value,
            is_admin = value.IsAdmin,
            password_hash = value.PasswordHash,
            username = value.Username
        };
    }
    
    public static Sensor.Domain.Entity.UserInfo ToDomainUserInfo(Sensor.Repository.Database.Poco.UserInfo value) {
        return new Entity.UserInfo(new UserId() { Value = value.id }) {
            Username = value.username??"",
            IsAdmin = value.is_admin,
            PasswordHash = value.password_hash??"",
        };
    }

    public static Sensor.Repository.Database.Poco.UserCookie ToPocoUserCookie(Sensor.Domain.Entity.UserCookie value) {
        return new UserCookie {
            id =  value.Id.Value,
            user_id = value.UserId.Value,
            end_datetime = value.EndDateTime
        };
    }
    
    public static Sensor.Domain.Entity.GraphRow ToDomainGraph(Sensor.Repository.Database.Poco.Graph value, GraphRowId graphRowId) {
        return new GraphRow(graphRowId) {
            Time = value.time,
            DeviceId = new IotId { Value = value.device_id },
            ValueKelvin = new Kelvin { Value = value.value_kelvin },
        };
    }

    public static Sensor.Repository.Database.Poco.Graph ToPocoGraph(Sensor.Domain.Entity.GraphRow value) {
        return new Repository.Database.Poco.Graph {
            time = value.Time,
            device_id = value.DeviceId.Value,
            value_kelvin = value.ValueKelvin.Value
        };
    }
    
    public static Sensor.Domain.Entity.Graph ToDomainGraph(Sensor.Repository.Database.Poco.Graph value) {
        return new Entity.Graph(new GraphId { Time = value.time, DeviceId = new () { Value = value.device_id }}) {
            ValueKelvin = new Kelvin { Value = value.value_kelvin },
        };
    }

    public static Sensor.Repository.Database.Poco.Graph ToPocoGraph(Entity.Graph value) {
        return new Repository.Database.Poco.Graph {
            time = value.Id.Time,
            device_id = value.Id.DeviceId.Value,
            value_kelvin = value.ValueKelvin.Value
        };
    }
}