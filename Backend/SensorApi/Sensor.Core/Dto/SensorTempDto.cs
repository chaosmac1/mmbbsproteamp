namespace SensorLib.Dto;

public record SensorTempDto(
    Guid MqttClientId, 
    DateTime CreateDate, 
    DateTime UseDate,
    float Value
);