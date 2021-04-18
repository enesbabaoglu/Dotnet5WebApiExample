using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNet5WebApiExample.Entities;

namespace DotNet5WebApiExample.Repositories.Concrete
{
    public class WebApiContext : DbContext
    {
        public DbSet<Student> Products { get; set; }
        public DbSet<ContactDetails> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasKey(c => new { c.Id });  //example
        }
    }
}

