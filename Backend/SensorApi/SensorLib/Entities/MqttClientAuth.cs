namespace SensorLib.Entities; 

public class MqttClientAuth {
    public Guid MqttClientId { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
}