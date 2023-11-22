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

public class HandlerSensorAddTemp: IHandler<DtoInputSensorNewData, IBody<ISensorData>> {
    public async Task<StatusOutput<IBody<ISensorData>>> HandlingAsync(
        DtoInputSensorNewData prop, 
        IDbWrapper dbWrapper, 
        IApiProxy apiProxy, 
        Option<UserIdAndToken> token) {

        var db = dbWrapper.Db;
        
        var jwt = Domain.ValueObject.Jwt.Parse(prop.Token);
        if (jwt.EndDate < DateTime.UtcNow) {
            return StatusOutput<IBody<ISensorData>>.AsOk(DtoBody<ISensorData>.HasError(Error.JwtDead));
        }
        
        var allowedRequestOp = (await ManagerIotDevice.FindByIdAsync(db, jwt.Id)).Map(x => x.AllowedRequest);
        
        if (allowedRequestOp.IsNotSet()) {
            return StatusOutput<IBody<ISensorData>>.AsOk(DtoBody<ISensorData>.HasError(Error.IotFoundByJwt));
        }

        if (!allowedRequestOp.Unwrap()) {
            return StatusOutput<IBody<ISensorData>>.AsOk(DtoBody<ISensorData>.HasError(Error.IotNotAllowedInsert));
        }

        var now = DateTime.UtcNow;
        var graph = new Graph(new GraphId { Time = now, DeviceId = jwt.Id }) {
            ValueKelvin = new Kelvin() { Value = prop.Kelvin }
        };
        
        await ManagerGraph.InsertOrUpdateAsync(db, graph);

        var graphRow = new GraphRow(GraphRowId.NewNoId()) {
            Time = graph.Id.Time,
            DeviceId = graph.Id.DeviceId,
            ValueKelvin = graph.ValueKelvin,
        };
        
        return StatusOutput<IBody<ISensorData>>.AsOk(DtoBody<ISensorData>.NoError(new DtoSensorData() {
            Kelvin = graphRow.ValueKelvin.Value,
            UseDate = graphRow.UseDate
        }));
    }
}