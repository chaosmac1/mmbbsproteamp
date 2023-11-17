using System.Diagnostics.CodeAnalysis;

namespace Sensor.Db.Poco; 

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class UserCookie {
    public string? id { get; set; }
    public DateTime end_datetime { get; set; }
    public Guid user_id { get; set; }
}