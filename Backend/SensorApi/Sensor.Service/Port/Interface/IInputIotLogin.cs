namespace Sensor.Service.Port.Interface;

public interface IInputIotLogin {
    public string IotName { get; }
    public string Password { get; }
}