using Sensor.Domain.Model;
using Sensor.Domain.ValueObject;

namespace Sensor.Domain.Entity; 

public class UserCookie: Entity<UserToken> {
    public required DateTime EndDateTime { get; set; }
    public required UserId UserId { get; set; }
    
    public UserCookie(UserToken id) : base(id) => Id = id;

    public static UserCookie NewCookie(UserId userId) {
        return new UserCookie(UserToken.NewUserToken()) {
            UserId = userId,
            EndDateTime = DateTime.UtcNow.AddDays(30) 
        };
    }
}