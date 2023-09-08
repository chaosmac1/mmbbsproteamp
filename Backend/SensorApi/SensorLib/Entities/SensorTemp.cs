namespace SensorLib.Entities; 

public class SensorTemp {
    public Guid MqttClientId { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UseDate { get; set; }
    public float Value { get; set; }
}