using System.Data;
using NLog;
using NLog.Config;
using NLog.Filters;
using NLog.Targets;
using Npgsql;
using Sensor.Env;

namespace Sensor.Log; 

public static class Logger {
    public static ILogger Setup() {
        var loggingConfiguration = new LoggingConfiguration();
        
        var consoleTarget = new ColoredConsoleTarget {
            AutoFlush = true,
            UseDefaultRowHighlightingRules = true
        };

        var dbSetting = SettingsBuilder(false);
        var dbTarget = new NLog.Targets.DatabaseTarget("db") {
            Name  = "db",
            DBProvider = "Npgsql.NpgsqlConnection, Npgsql",
            ConnectionString = dbSetting.ToString(),
            IsolationLevel = IsolationLevel.Unspecified,
            KeepConnection = true,
            CommandText = @"
insert 
into public.log
    (log_date,log_level,log_logger,log_message, log_call_site, log_thread, log_exception, log_stacktrace) 
values
    (@time_stamp, @level, @logger, @message, @call_site, @threadid, @log_exception, @stacktrace);",
            
        };
            
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@time_stamp", "${longdate}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@level", "${level}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@logger", "${logger}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@message", "${message}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@call_site", "${callsite:filename=true}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@threadid", "${threadid}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@log_exception", "${exception:tostring}"));
        dbTarget.Parameters.Add(new DatabaseParameterInfo("@stacktrace", "${stacktrace}"));
        
        loggingConfiguration.AddTarget("console", consoleTarget);
        loggingConfiguration.AddTarget("db", dbTarget);

        var min = LogLevel.FromString(Env.Env.MinLogging)??throw new NullReferenceException("minLevel");
        var max = LogLevel.FromString(Env.Env.MaxLogging)??throw new NullReferenceException("maxLevel");

        var filter = new WhenMethodFilter(static info => {
            var result = info.Level.Ordinal switch {
                // Trace;
                // Debug;
                // Info;
                0 or 1 or 2 => LoggerNameIsMicrosoft(info.LoggerName ?? "")
                    ? FilterResult.IgnoreFinal
                    : FilterResult.Log,

                // Warn;
                // Error;
                // Fatal;
                3 or 4 or 5 => FilterResult.Log,
                // Off;
                6 => FilterResult.IgnoreFinal,
                _ => FilterResult.IgnoreFinal
            };

            return result;
        });
        
        var ruleDb = new LoggingRule("*", min, max, dbTarget) { Filters = { filter } };
        var ruleConsole = new LoggingRule("*", min, max, consoleTarget) { Filters = { filter } };
        // ruleElse.Targets.Add(dbTarget);
        
        loggingConfiguration.AddRule(ruleDb);
        loggingConfiguration.AddRule(ruleConsole);
        
        return NLog.LogManager
                         .Setup()
                         .LoadConfiguration(loggingConfiguration)
                         .GetCurrentClassLogger();
    }

    private static bool LoggerNameIsMicrosoft(string loggerName) 
        => loggerName.StartsWith("Microsoft.", StringComparison.Ordinal);
    
    private static NpgsqlConnectionStringBuilder SettingsBuilder(bool multiplexing = true) {
        var connStringBuilder = new NpgsqlConnectionStringBuilder();
        connStringBuilder.Host         = Setting.Host; 
        connStringBuilder.Port         = Setting.Port; 
        connStringBuilder.Password     = Setting.Password; 
        connStringBuilder.Username     = Setting.Username; 
        connStringBuilder.Database     = Setting.Database; 
        connStringBuilder.Pooling      = Setting.Pooling; 
        connStringBuilder.MaxPoolSize  = Setting.MaxPoolSize; 
        connStringBuilder.MinPoolSize  = Setting.MinPoolSize; 
        connStringBuilder.Timeout      = Setting.Timeout; 
        connStringBuilder.Multiplexing = multiplexing;
        return connStringBuilder;
    }
}