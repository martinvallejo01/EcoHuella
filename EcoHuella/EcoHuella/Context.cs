using EcoHuella.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace EcoHuella
{
    public class Context : DbContext
    {
        private String _dbPath;

        public DbSet<User> User { get; set; }
        public DbSet<EcoFootPrint> EcoFootPrint { get; set; }

        public Context(String dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreatedAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("**** OnConfiguring");
            optionsBuilder.UseSqlite($"Filename={_dbPath}", x=>x.SuppressForeignKeyEnforcement());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EcoFootPrint>()
                .HasKey(efp => efp.FootPrintID);

            modelBuilder.Entity<EcoFootPrint>()
                .HasOne(x => x.User)
                .WithMany(x => x.FootPrints)
                .HasForeignKey("UserID");
        }
    }
}
