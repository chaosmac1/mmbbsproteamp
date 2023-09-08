namespace SensorLib.Dto; 

public record MqttClientAuthDto(
    Guid MqttClientId,
    string Name,
    string PasswordHash
);