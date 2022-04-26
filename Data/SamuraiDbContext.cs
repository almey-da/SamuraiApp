using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class SamuraiDbContext : DbContext
    {
        public SamuraiDbContext(DbContextOptions<SamuraiDbContext> opt) : base(opt)
        {

        }

         public DbSet<Samurai> Samurais { get; set; }
         public DbSet<Sword> Swords { get; set; }
         public DbSet<Element> Elements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
