using System.Diagnostics.CodeAnalysis;

namespace Sensor.Db.Poco; 

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class UserInfo {
    public Guid id { get; set; }
    public string? username { get; set; }
    public string? password_hash { get; set; }
    public bool is_admin { get; set; }  
}