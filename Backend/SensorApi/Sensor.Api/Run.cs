namespace Sensor.Api; 

public class Run {
    private static Logger Log = LogManager.GetCurrentClassLogger();
    
    public static void RunWebApi() {
        Log.Debug("Start RunWebApi");
        if (Setup.WebApplication is null) {
            Log.Error("{0} Is Null", nameof(Setup.WebApplication));
            throw new NullReferenceException(nameof(Setup.WebApplication));
        }
        Setup.WebApplication.Run();
    }
}