using System.Diagnostics.CodeAnalysis;

namespace Sensor.Repository.Database.Poco; 

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Graph {
    public Guid device_id { get; set; }
    public DateTime time { get; set; }
    public float value_kelvin { get; set; }
}