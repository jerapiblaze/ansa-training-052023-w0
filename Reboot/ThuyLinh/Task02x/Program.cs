using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();

var app = builder.Build();

void ConfigureServices(IServiceCollection services) {

    //...
    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    services.AddHealthChecks();
    services.AddMvc();

    //...
}

app.Run();