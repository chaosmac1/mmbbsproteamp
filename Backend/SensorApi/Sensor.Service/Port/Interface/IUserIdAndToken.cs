namespace Sensor.Service.Port.Interface; 

public interface IUserIdAndToken {
    public Guid UserId { get; }
    public string CookieToken { get; }
}