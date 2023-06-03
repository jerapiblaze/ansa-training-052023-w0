using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcStudent.Data;
using System;
using System.Linq;

namespace MvcStudent.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcStudentContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcStudentContext>>()))
        {
            // Look for any movies.
            if (context.Student.Any())
            {
                return;   // DB has been seeded
            }
            context.Student.AddRange(
                new Student
                {
                    id = 20212860,
                    name = "Trương Đức Nhật",
                    GPA = 3.5
                },
                new Student
                {
                    id = 20211793,
                    name = "Tùng Linh",
                    GPA = 3.2
                },
                new Student
                {
                    id = 20214111,
                    name = "Nguyễn Trọng Tín",
                    GPA = 3.4
                }
            );
            context.SaveChanges();
        }
    }
}