using Riok.Mapperly.Abstractions;
using Sensor.Api.Interface;
using Sensor.Api.View;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Port.Interface;

namespace Sensor.Api; 

[Mapper]
public static partial class Mapper {
    public static ViewBody<TOut> ToView<TOut>(IBody body) where TOut: class, IView {
        if (body.Data is null) {
            return new ViewBody<TOut>() {
                Data = null,
                Error = body.Error,
                ErrorId = body.ErrorId,
                ErrorMessage = body.ErrorMessage, 
            };
        }
        
        return new ViewBody<TOut>() {
            Data = (TOut)(object)(body.Data switch {
                IIotInfo @a => ToView(@a),
                IIotInfos @a => ToView(@a),
                IIotLogin @a => ToView(@a),
                IIotName @a => ToView(@a),
                IIotUpdate @a => ToView(@a),
                ISensorData @a => ToView(@a),
                ISensorDatas @a => ToView(@a),
                IUserInfo @a => ToView(@a),
                IUserInfos @a => ToView(@a),
                IUserLoginStatus @a => ToView(@a),
                IValid @a => ToView(@a),
                IWork @a => ToView(@a),
                _ => throw new ArgumentOutOfRangeException()
            }),
            Error = body.Error,
            ErrorId = body.ErrorId,
            ErrorMessage = body.ErrorMessage, 
        };
    }

    public static ViewIotInfo ToView(IIotInfo value) {
        return new ViewIotInfo() {
            Name = value.Name,
            LastRequest = value.LastRequest,
            AllowedRequest = value.AllowedRequest,
        };
    }
    public static partial ViewIotInfos ToView(IIotInfos value);
    public static partial ViewIotLoginJwtAndStatus ToView(IIotLogin value);
    public static partial ViewIotName ToView(IIotName value);
    public static partial ViewIotUpdate ToView(IIotUpdate value);

    public static ViewSensorData ToView(ISensorData value) {
        return new ViewSensorData() {
            UseDate = value.UseDate.Date,
            Kelvin = value.Kelvin
        };
    }

    public static ViewSensorDatas ToView(ISensorDatas value) {
        return new () { SensorDatas = value.SensorDatas.Select(ToView).ToList() };
    }
    public static partial ViewUserInfo     ToView(IUserInfo value);

    public static ViewUserInfos ToView(IUserInfos value) {
        return new () { List = value.List.Select(ToView).ToList()  };
    }
    public static partial ViewUserLogin    ToView(IUserLoginStatus value);
    public static partial ViewValid        ToView(IValid value);
    public static partial ViewWork         ToView(IWork value);
}