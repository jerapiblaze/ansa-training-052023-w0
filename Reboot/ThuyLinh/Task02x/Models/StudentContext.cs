using Microsoft.EntityFrameworkCore;

namespace StudentApi.Models;

public class StudentContext : DbContext
{
    public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
    {
    }

    public DbSet<StudentItem> StudentItems { get; set; } = null!;
}





