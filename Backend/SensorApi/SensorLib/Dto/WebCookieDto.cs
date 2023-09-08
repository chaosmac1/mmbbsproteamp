namespace SensorLib.Dto; 

public record WebCookieDto(
    Guid TokenId,
    Guid UserId,
    DateTime CreateDate,
    bool IsAdmin
);