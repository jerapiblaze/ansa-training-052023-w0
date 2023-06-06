using Microsoft.EntityFrameworkCore;
namespace _0._2._1;
public class ApplicationDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}



