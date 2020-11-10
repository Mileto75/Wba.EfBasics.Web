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

        //verplichte constructor met base call!!
        public SchoolDbContext
            (DbContextOptions<SchoolDbContext> options)
            :base(options)
        {
        }
    }
}
