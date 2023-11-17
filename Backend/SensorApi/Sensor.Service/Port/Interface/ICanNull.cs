namespace Sensor.Service.Port.Interface;

public interface ICanNull<T> where T: class {
    public T? Value { get; }
}