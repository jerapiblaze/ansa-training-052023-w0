using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Task02x.Controllers;
using Task02x.Core.DTOs;
using Task02x.Core.Models;
using Task02x.Core.Repositories;
using Task02x.Core;
using Task02x.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();
builder.Services.AddControllers();
builder.Services.AddMvcCore();

builder.Services.AddDbContext<AppicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("AppicationDbContext")));

builder.Services.AddScoped<IOperation, Operation>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

app.UseRouting();

app.MapGet("/", () => {
    return "Hello World! This is an API Server with MVC.";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action}/{id?}");

app.Run();
