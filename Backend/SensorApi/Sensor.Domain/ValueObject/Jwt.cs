using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Sensor.Domain;

namespace Sensor.Domain.ValueObject; 

public class Jwt: Model.ValueObject {
    public required IotId Id { get; set; }
    public required DateTime EndDate { get; set; }
    
    internal override IEnumerable<object> GetEquality() {
        yield return Id;
        yield return EndDate;
    }

    public static Jwt Parse(string value) {
        IJsonSerializer serializer = new JsonNetSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtDecoder decoder = new JwtDecoder(serializer, urlEncoder);
        var key =  Sensor.Env.Env.JwtKey; 
        var dictionary = decoder.DecodeHeaderToDictionary(key);

        var id = new IotId { Value = Guid.Parse(dictionary["Id.Value"]) };
        var endDate = DateTime.FromBinary(long.Parse(dictionary["EndDate"]));
        
        var jwt = new Jwt {
            Id = id,
            EndDate = endDate,
        };

        return jwt;
    }

    public string ToJwt() {
        var payload = new Dictionary<string, object>
        {
            { "Id.Value", Id.Value },
            { "EndDate", EndDate.ToBinary() }
        };
        
        IJwtAlgorithm algorithm = new HMACSHA512Algorithm();
        IJsonSerializer serializer = new JsonNetSerializer();
        IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
        IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
        var key = Sensor.Env.Env.JwtKey;

        var jwt = encoder.Encode(payload, key);
        return jwt;
    }
}