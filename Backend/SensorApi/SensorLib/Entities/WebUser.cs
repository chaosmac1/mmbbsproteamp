namespace SensorLib.Entities; 

public class WebUser {
    public Guid UserId { get; set; }
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public bool IsAdmin { get; set; }
}