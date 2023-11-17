namespace Sensor.Service.Port.Interface;

public interface IInputAdminIotUpdate<T> where T: ICanNull<string> {
    public string IotId { get; }
    public T UpdateId { get; }
    public bool AllowedRequest { get; }
}