namespace Sensor.Service.Port.Interface;

public interface IInputAdminSetUserPassword {
    public Guid UserId { get; }
    public string Password { get; }
}