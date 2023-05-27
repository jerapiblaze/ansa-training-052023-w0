using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Task02x.Core.Models;

namespace Task02x.Persistence
{
    public class AppicationDbContext : DbContext
    {
        public AppicationDbContext(DbContextOptions<AppicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}