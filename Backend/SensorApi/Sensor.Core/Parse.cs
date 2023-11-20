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
        return new UserInfo(new UserId() { Value = value.id }) {
            Username = value.username??"",
            IsAdmin = value.is_admin,
            PasswordHash = value.password_hash??"",
        };
    }
}