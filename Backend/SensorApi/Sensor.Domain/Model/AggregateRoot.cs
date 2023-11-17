namespace Sensor.Domain.Model; 

public abstract class AggregateRoot<TId> : Entity<TId> {
    internal AggregateRoot(TId id) : base(id) { }
}