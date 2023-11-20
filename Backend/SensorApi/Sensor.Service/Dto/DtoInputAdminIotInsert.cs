using Sensor.Domain.ValueObject;
using Sensor.Service.AttachmentService.Interface;

namespace Sensor.Service.Dto; 

public record DtoInputAdminIotInsert(string Name): IDto;