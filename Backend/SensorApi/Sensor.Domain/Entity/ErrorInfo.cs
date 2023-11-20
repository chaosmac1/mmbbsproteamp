using Sensor.Domain.Model;
using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class ErrorInfo(ErrorId id, string message) : Entity<ErrorId>(id) {
    public string Message { get; init; } = message;
}