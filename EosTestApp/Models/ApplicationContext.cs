using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EosTestApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ActivitySphere> ActivitySpheres { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();   
        }
    }
}
