namespace Sensor.Service.AttachmentService.Interface;

public interface IValidation<T> where T: IDto {
    public bool Validate(T value);
}