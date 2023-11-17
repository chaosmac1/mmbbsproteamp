using LamLibAllOver;
using Sensor.Service.AttachmentService;

namespace Sensor.Service.Port; 

public class StatusOutput<T> {
    public required Option<T> Value { get; set; }
    public required EStatus Status { get; set; }
    public required string InternelMessage { get; set; }

    public static StatusOutput<T> AsOk(T value) {
        return new StatusOutput<T>() {
            Status = EStatus.Ok,
            Value = Option<T>.With(value),
            InternelMessage = ""
        };
    }

    public static StatusOutput<T> AsBadRequest() {
        return new StatusOutput<T>() {
            Status = EStatus.BadRequest,
            Value = default,
            InternelMessage = ""
        };
    }

    public static StatusOutput<T> AsBadRequestWithMessage(T value) {
        return new StatusOutput<T>() {
            Status = EStatus.BadRequestMessage,
            Value = Option<T>.With(value),
            InternelMessage = ""
        };
    }
    public static StatusOutput<T> AsForbidden() {
        return new StatusOutput<T>() {
            Status = EStatus.Forbidden,
            Value = default,
            InternelMessage = ""
        };
    }

    public static StatusOutput<T> AsInternelServerError(string text) {
        return new StatusOutput<T>() {
            Status = EStatus.InternelServerError,
            Value = default,
            InternelMessage = text
        };
    }

    public static StatusOutput<T> AsInternelServerError(ResultErr<string> text) {
        return new StatusOutput<T>() {
            Status = EStatus.InternelServerError,
            Value = default,
            InternelMessage = text.Err()
        };
    } 
}