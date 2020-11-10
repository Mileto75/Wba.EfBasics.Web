using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wba.EfBasics.Domain.Entities;

namespace Wba.EfBasics.Web.Data
{
    public class MovieDbContext : DbContext
    {
        //hier komen de entities als DbSets
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        //Base constructor aanroepen
        public MovieDbContext
            (DbContextOptions<MovieDbContext> options):base(options)
        {

        }
    }
}
