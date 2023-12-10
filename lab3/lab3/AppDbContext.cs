using lab3;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace lab3
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Contact> Contacts { get; set; }

        public string DbPath { get; }

        public AppDbContext()
        {
            var path = "C:\\Users\\rawline\\source\\repos\\lab3\\lab3\\bin\\Debug\\net7.0";
            DbPath = Path.Join(path, "contact.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity => entity.ToTable("contact"));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
