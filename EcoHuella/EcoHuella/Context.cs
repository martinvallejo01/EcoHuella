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

        public DbSet<Food> Food { get; set; }
        public DbSet<Travel> Travel { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EcoFootPrint> EcoFootPrint { get; set; }

        public Context(String dbPath) : base()
        {
            _dbPath = dbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Debug.WriteLine("**** OnConfiguring");
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EcoFootPrint>()
                .HasKey(f => f.FootPrintID);
            modelBuilder.Entity<EcoFootPrint>()
                .HasOne(f => f.User)
                .WithMany(u => u.FootPrints);
            modelBuilder.Entity<EcoFootPrint>()
                .HasOne(f => f.Food)
                .WithOne(f => f.FootPrint)
                .HasForeignKey("FoodID");
            modelBuilder.Entity<EcoFootPrint>()
                .HasOne(f => f.Home)
                .WithOne(h => h.FootPrint)
                .HasForeignKey("HomeID");
            modelBuilder.Entity<EcoFootPrint>()
                .HasOne(f => f.Travel)
                .WithOne(h => h.FootPrint)
                .HasForeignKey("TravelID");

            modelBuilder.Entity<Food>()
                .HasKey(f => f.FoodID);

            modelBuilder.Entity<Travel>()
                .HasKey(t => t.TravelID);

            modelBuilder.Entity<Home>()
                .HasKey(h => h.HomeID);
        }
    }
}
