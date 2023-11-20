using Sensor.Domain.Enum;

namespace Sensor.Service.Port.Interface; 

public interface IUserLoginStatus {
    public string Status { get;  }
}