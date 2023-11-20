namespace Sensor.Service.Port.Interface; 

public interface IUserInfo {
    public Guid UserId { get; }
    public string Username { get; }
}