using System.Diagnostics.CodeAnalysis;

namespace Sensor.Db.Poco; 

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Graph {
    public long id { get; set; }
    public Guid device_id { get; set; }
    public DateTime time { get; set; }
    public float value_kelvin { get; set; }
}