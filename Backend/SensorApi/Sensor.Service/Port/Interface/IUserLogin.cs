using Sensor.Domain.Enum;

namespace Sensor.Service.Port.Interface; 

public interface IUserLogin {
    public EUserLogin Status { get;  }
}