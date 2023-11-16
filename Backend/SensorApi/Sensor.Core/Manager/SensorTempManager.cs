using System.Runtime.InteropServices.JavaScript;
using Npgsql;
using SensorLib.Dto;
using SensorLib.Query;

namespace Sensor.Core.Manager; 

public static class SensorTempManager {
    public static async ValueTask<IReadOnlyList<SensorTempGroupDto>> GetSensorDataAsBetweenAsync(
        NpgsqlConnection db,
        DateTime start,
        DateTime end) {

        return (await QuerySensorTemp.GetByRangeDateAndGroupByUseDateAsync(db, start, end))
            .Select(Mapper.ToSensorTempGroupDto)
            .ToList();
    }

    public static async ValueTask InsertAsync(NpgsqlConnection db, SensorTempDto value) {
        await QuerySensorTemp.InsertAsync(db, Mapper.FromDto(value));
    }
}