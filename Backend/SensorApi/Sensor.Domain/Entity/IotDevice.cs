using Sensor.Domain.ValueObject;
using Sensor.Domain.Model;

namespace Sensor.Domain.Entity; 

public class IotDevice: Entity<IotId> {
    public string? Name { get; set; }
    public DateTime LastRequest { get; set; }
    public bool AllowedRequest { get; set; }

    public IotDevice(IotId id) : base(id) => Id = id;
}