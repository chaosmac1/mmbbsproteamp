namespace Sensor.Domain.ValueObject; 

public class ErrorId: Model.ValueObject {
    public int Id { get; set; }
    internal override IEnumerable<object> GetEquality() {
        yield return Id;
    }
    
    public ErrorId(int id) {
        Id = id;
    }
}