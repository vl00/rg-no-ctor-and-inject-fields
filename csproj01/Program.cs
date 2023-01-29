using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

var appbuilder = WebApplication.CreateBuilder(args);
{
    appbuilder.Host.ConfigureAppConfiguration((ctx, builder) =>
    {
        var cbuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory());

        ctx.Configuration = cbuilder.Build();
    })
    .ConfigureLogging((ctx, builder) =>
    {
        
    })
    .ConfigureServices((ctx, services) =>
    {
        services.AddOptions();

        services.AddTransient<lib01.Class1>();
        services.AddTransient<lib02.Class2>();
        services.AddTransient<lib02.Class3>();
        services.AddTransient<lib01.Class4>();
    });
}
void OnApplicationStarted(IServiceProvider services)
{
    services.GetService<ILoggerFactory>().CreateLogger("app").LogInformation("web app started");

    Debugger.Break();
    var c1 = services.GetService<lib01.Class1>();
    var c2 = services.GetService<lib02.Class2>();
    var c3 = services.GetService<lib02.Class3>();
    var c4 = services.GetService<lib01.Class4>();
    Debugger.Break();
}
void OnApplicationStopping(IServiceProvider services)
{
    services.GetService<ILoggerFactory>().CreateLogger("app").LogInformation("web app stopping");
}
await using var app = appbuilder.Build();
{
    //app.Lifetime
    app.Lifetime.ApplicationStarted.Register(o =>
    {
        OnApplicationStarted(app.Services);
    }, null, false);
    app.Lifetime.ApplicationStopping.Register(o =>
    {
        OnApplicationStopping(app.Services);
    }, null, false);

    app.UseRouting();

    app.MapGet("/", () => "Hello World");
}
await app.RunAsync();
// end