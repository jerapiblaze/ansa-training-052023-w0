using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task02x.Persistence;
using System;
using System.Linq;
using Task02x.Utils;

namespace Task02x.Core.Models;

public class SeedData {
    public static void Initialize(IServiceProvider serviceProvider){
        using (var context = new AppicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppicationDbContext>>()
        )){
            if (context.Students.Any()){
                return;
            }
            context.Students.AddRange(
                new Student{
                    Id = 1000,
                    Name = "Chris",
                    Secret = RandomString.GenerateString(10, true, true, true),
                    Point = 10.0
                },
                new Student{
                    Id = 1001,
                    Name = "Jesus",
                    Secret = RandomString.GenerateString(10, true, true, true),
                    Point = 9.0
                }
            );
            context.SaveChanges();
        }
    }
}