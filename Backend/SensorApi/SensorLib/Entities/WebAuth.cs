namespace SensorLib.Entities; 

public class WebAuth {
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
}