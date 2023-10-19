using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Core.Entities;

namespace Wba.EfBasics.Web.Data
{
    public class SchoolDbContext : DbContext
    {
        //add DbSet properties
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
