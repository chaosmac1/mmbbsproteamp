using Sensor.Domain.Model;
using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class UserInfo: Entity<UserId> {
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public required bool IsAdmin { get; set; }  
    
    public UserInfo(UserId id) : base(id) => Id = id;
}