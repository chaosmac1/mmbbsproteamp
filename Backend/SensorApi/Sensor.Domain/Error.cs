using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;

namespace Sensor.Domain; 

public static class Error {
    public static ErrorInfo UserNotFoundByCookie = new ErrorInfo(new ErrorId(1), "User Not Found By Cookie");
    public static ErrorInfo IotFoundByJwt = new ErrorInfo(new ErrorId(1), "Iot Device Not Found By Jwt");
    public static ErrorInfo IotNameExist = new ErrorInfo(new ErrorId(2), "Can Not Name Iot Device If Name In Use From A Other Iot Device");
    public static ErrorInfo UpdateTargetNotFound = new ErrorInfo(new ErrorId(2), "Domain Target Not Found For A Update");
}