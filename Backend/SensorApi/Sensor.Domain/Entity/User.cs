using Sensor.Domain.Model;
using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class User: Entity<UserId> {
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required bool IsAdmin { get; set; }  
    
    public User(UserId id) : base(id) => Id = id;
}