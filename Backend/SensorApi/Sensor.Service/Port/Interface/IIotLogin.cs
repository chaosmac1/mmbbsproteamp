using Sensor.Domain.Enum;
using Sensor.Domain.ValueObject;

namespace Sensor.Service.Port.Interface; 

public interface IIotLogin {
    public EIotLogin Status { get;  }
    public IotToken Token { get;  }
}