// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Filters;


var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("serilog.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Filter.ByExcluding(Matching.FromSource("PartialLog.Off"))
    .Filter.ByExcluding(Matching.FromSource("LibWithLoggingTurnedOff"))
    .CreateLogger();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();


Log.Information("Tohle je log z main classy!");

LibWithLogging.MyClass.Hello();
LibWithLoggingTurnedOff.MyClass.Hello();
PartialLog.Off.MyClass.Hello();
PartialLog.Off.Sub.MyClass.Hello();
PartialLog.On.MyClass.Hello();


Log.CloseAndFlush();
Console.WriteLine("---konec---");