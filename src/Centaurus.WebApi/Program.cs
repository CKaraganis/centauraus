namespace Centaurus.WebApi;

using Serilog;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        BuildConfiguration(builder);

        var logger = new LoggerConfiguration()
            .CreateLogger();

        Log.Logger = logger;
        builder.Services.AddSerilog(logger);
        
        var app = builder.Build();

        app.UseStaticFiles();

        app.Run();
    }

    private static void BuildConfiguration(WebApplicationBuilder builder)
    {
        builder.Configuration
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional:true)
            .AddJsonFile("serilog.settings.json")
            .AddJsonFile($"serilog.settings.{builder.Environment.EnvironmentName}.json", optional:true)
            .AddEnvironmentVariables()
            .AddUserSecrets<Program>(optional:true);
    }
}