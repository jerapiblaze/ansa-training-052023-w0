using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _0._2._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            InitializeDatabase(host);
            host.Run();
        }

        private static void InitializeDatabase(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();

                if (!dbContext.Students.Any())
                {
                    var students = new List<Student>
                    {
                        new Student { Name = "Minh", Id = 20214010 },
                        new Student { Name = "MLH", Id = 20213962 },
                        new Student { Name = "Tung", Id = 20214032 },
                        new Student { Name = "Dat", Id = 20210321 }
                    };

                    dbContext.Students.AddRange(students);
                    dbContext.SaveChanges();
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddDbContext<ApplicationDbContext>(options =>
                        {
                            options.UseSqlite("Data Source=students.db");
                        });
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGet("/", async context =>
                            {
                                await context.Response.WriteAsync("Hello World!");
                            });

                            endpoints.MapGet("/students", async context =>
                            {
                                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();
                                var students = dbContext.Students.ToDictionary(s => s.Id, s => s.Name);
                                var json = JsonSerializer.Serialize(students);
                                context.Response.ContentType = "application/json";
                                await context.Response.WriteAsync(json);
                            });

                            endpoints.MapPost("/students", async context =>
                            {
                                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();

                                var requestBody = await context.Request.ReadFromJsonAsync<Student>();
                                if (requestBody != null)
                                {
                                    var student = new Student { Name = requestBody.Name, Id = requestBody.Id };
                                    dbContext.Students.Add(student);
                                    await dbContext.SaveChangesAsync();

                                    context.Response.StatusCode = 201; // Created
                                    await context.Response.WriteAsync($"Created new student with ID: {student.Id}");
                                }
                                else
                                {
                                    context.Response.StatusCode = 400; // Bad Request
                                    await context.Response.WriteAsync("Invalid student data");
                                }
                            });

                            endpoints.MapPut("/students/{id}", async context =>
                            {
                                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();

                                if (int.TryParse(context.Request.RouteValues["id"]?.ToString(), out int id))
                                {
                                    var student = await dbContext.Students.FindAsync(id);
                                    if (student != null)
                                    {
                                        var requestBody = await context.Request.ReadFromJsonAsync<Student>();
                                        if (requestBody != null)
                                        {
                                            student.Name = requestBody.Name;
                                            await dbContext.SaveChangesAsync();

                                            context.Response.StatusCode = 200; // OK
                                            await context.Response.WriteAsync($"Updated student name with ID: {student.Id}");
                                            return;
                                        }
                                        else
                                        {
                                            context.Response.StatusCode = 400; // Bad Request
                                            await context.Response.WriteAsync("Invalid student data");
                                            return;
                                        }
                                    }
                                }

                                context.Response.StatusCode = 404; // Not Found
                                await context.Response.WriteAsync("Student not found");
                            });


                            endpoints.MapDelete("/students/{id}", async context =>
                            {
                                var dbContext = context.RequestServices.GetRequiredService<ApplicationDbContext>();

                                if (int.TryParse(context.Request.RouteValues["id"]?.ToString(), out int id))
                                {
                                    var student = await dbContext.Students.FindAsync(id);
                                    if (student != null)
                                    {
                                        dbContext.Students.Remove(student);
                                        await dbContext.SaveChangesAsync();

                                        context.Response.StatusCode = 204; // No Content
                                        return;
                                    }
                                }

                                context.Response.StatusCode = 404; // Not Found
                                await context.Response.WriteAsync("Student not found");
                            });
                        });
                    });
                });
    }
}
