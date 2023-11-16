namespace Sensor.Domain.Entities; 

public class GraphRow {
    public int Posi { get; set; }
    public DateTime Time { get; set; }
    public float ValueKelvin { get; set; }
}