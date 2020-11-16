using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Domain.Entities;

namespace Wba.EfBasics.Web.Data
{
    public class SchoolDbContext : DbContext
    {
        //properties van deze class
        //stellen de tabellen voor in de 
        //Database = Entities
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }

        //verplichte constructor met base call!!
        public SchoolDbContext
            (DbContextOptions<SchoolDbContext> options)
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one on one relatie met Fluent Api
            modelBuilder.Entity<ContactInfo>()
                .HasOne(c => c.Teacher)
                .WithOne(t => t.ContactInfo)
                .HasForeignKey<ContactInfo>(c => c.TeacherId);

            // one to many relatie met Fluent Api
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany(t => t.Courses)
                .HasForeignKey(c => c.TeacherId);

            //Many to Many relatie
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
