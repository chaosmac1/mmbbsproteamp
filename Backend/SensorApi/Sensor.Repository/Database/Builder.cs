using Npgsql;

namespace Sensor.Repository.Database; 

public static class Builder {
    public static Func<Task<IDbWrapper>> BuildDbWrapper = () => throw new Exception("Not Setup");
}