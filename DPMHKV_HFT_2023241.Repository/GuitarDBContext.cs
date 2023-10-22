using System;
using DPMHKV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace DPMHKV_HFT_2023241.Repository
{
    internal class GuitarDBContext:DbContext  
    {
        public DbSet<Guitar> Guitars { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public GuitarDBContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
                string conn = @"";
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
            }
        }
    }
}
