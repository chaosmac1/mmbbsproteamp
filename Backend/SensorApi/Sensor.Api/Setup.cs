using NLog;
using NLog.Web;
using WebApplication = Microsoft.AspNetCore.Builder.WebApplication;

namespace Sensor.Api; 

public static class Setup {
    private static Logger log = LogManager.GetCurrentClassLogger();
    
    public static WebApplication? WebApplication = null;
    
    public static async Task RunAsync(string[] args) {
        try {
            // Logging
            Sensor.Log.Logger.Setup();
        
            // DB
            Sensor.Repository.Database.Builder.BuildDbWrapper = Sensor.Db.DbWrapper.FactoryAsync;
            
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers(options => { });
            builder.Logging.ClearProviders();
            builder.Host.UseNLog(new NLogAspNetCoreOptions() { });
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x => {
                
            });

            WebApplication app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger(options => {});
                app.UseSwaggerUI(options => {});
            }

            // app.UseHttpsRedirection();

            // app.UseAuthorization();

            app.MapControllers();

            WebApplication = app;
        }
        catch (Exception e)
        {
            log.Error(e, "Setup Web API");
            throw;
        }
    }
}