using SensorLib.Database;

namespace SensorLib.AttachmentService.Interface; 

public interface IValidation<T> where T: IRequest {
    public ValueTask<bool> Validate(T value, DbWrapper db);
}