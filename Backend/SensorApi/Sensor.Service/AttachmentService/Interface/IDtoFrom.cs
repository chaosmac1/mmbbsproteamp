namespace Sensor.Service.AttachmentService.Interface;

public interface IDto;

public interface IDtoFrom<TTo, TFrom> {
    public static abstract TTo From(TFrom from);
}
public interface IDtoTo<TTo> {
    public TTo To();
}