using System;
using DPMHKV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace DPMHKV_HFT_2023241.Repository
{
    internal class GuitarDBContext : DbContext
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guitar>(guitar =>
            {
                guitar
                .HasOne(guitar => guitar.Brand)
                .WithMany()
                .HasForeignKey(guitar => guitar.BrandID)
                .OnDelete(DeleteBehavior.Cascade);

                guitar
                .HasOne(guitar => guitar.Musician) //not sure about this part 
                .WithMany()
                .HasForeignKey(guitar => guitar.MusicianID)
                .OnDelete(DeleteBehavior.Cascade);
                
            });
            modelBuilder.Entity<Guitar>().HasData(new Guitar[]
                {
                    new Guitar()
                });
            
            
        }
    }
}
