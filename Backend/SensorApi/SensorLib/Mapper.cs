using Riok.Mapperly.Abstractions;
using SensorLib.Dto;
using SensorLib.Entities;

namespace SensorLib; 

[Mapper]
public static partial class Mapper {
    public static partial MqttClientAuthDto ToMqttClientAuthDto(MqttClientAuth value);
    public static partial SensorTempDto ToSensorTempDto(SensorTemp value);
    public static partial SensorTempGroupDto ToSensorTempGroupDto(SensorTemp value);
    
    public static partial MqttClientAuth FromDto(MqttClientAuthDto value);
    public static partial SensorTemp FromDto(SensorTempDto value);
    public static partial SensorTemp FromDto(SensorTempGroupDto value);
}