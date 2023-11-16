namespace SensorLib.Entities; 

public class WebCookie {
    public Guid TokenId { get; set; }
    public Guid UserId { get; set; }
    public DateTime CreateDate { get; set; }
}