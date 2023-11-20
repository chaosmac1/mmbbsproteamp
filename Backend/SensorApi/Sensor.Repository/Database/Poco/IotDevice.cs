using System.Diagnostics.CodeAnalysis;

namespace Sensor.Repository.Database.Poco;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class IotDevice {
    public Guid id { get; set; }
    public string? name { get; set; }
    public DateTime last_request { get; set; }
    public bool allowed_request { get; set; }
}