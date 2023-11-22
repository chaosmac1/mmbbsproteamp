using LamLibAllOver;
using Sensor.Domain;
using Sensor.Domain.Entity;
using Sensor.Domain.ValueObject;
using Sensor.Repository.Database;
using Sensor.Service.AttachmentService.Interface;
using Sensor.Service.Dto;
using Sensor.Service.Port;
using Sensor.Service.Port.Interface;

namespace Sensor.Service.Handler;

public class HandlerSensorGetData: IHandler<DtoAmount, IBody<ISensorDatas>> {
    public async Task<StatusOutput<IBody<ISensorDatas>>> HandlingAsync(
        DtoAmount prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        if (token.IsNotSet()) {
            return StatusOutput<IBody<ISensorDatas>>.AsOk(DtoBody<ISensorDatas>.HasError(Error.UserNotFoundByCookie));
        }
        
        var db = dbWrapper.Db; 
        
        var end = DateTime.UtcNow;
        var start = end - TimeSpan.FromSeconds(10 * prop.Amount);

        var range = (await ManagerGraphRow.GetGraphRowByTimeRangeAsync(db, start, end)).MergeByUseDate();
        
        return StatusOutput<IBody<ISensorDatas>>.AsOk(DtoBody<ISensorDatas>.NoError(new DtoSensorDatas {
            SensorDatas = range.Rows.Select(x => new DtoSensorData {
                Kelvin = x.ValueKelvin.Value,
                UseDate = x.UseDate
            }).ToList()
        }));
    }
}