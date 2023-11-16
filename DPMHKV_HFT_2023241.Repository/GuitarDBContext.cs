using System;
using DPMHKV_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;

namespace DPMHKV_HFT_2023241.Repository
{
    public class GuitarDBContext : DbContext
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
                optionsBuilder.UseInMemoryDatabase("GuitarDB").UseLazyLoadingProxies();
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
            modelBuilder.Entity<Musician>().HasData(new Musician[]
            {
                    new Musician("1#John Lennon#The Beatles"),
                    new Musician("2#Jimi Hendrix#The Jimi Hendrix Experience"),
                    new Musician("3#Lukács Péter#Bikini"),
                    new Musician("4#John Mayer#The John Mayer Experience"),
                    new Musician("5#Brian May#Queen"),
                    new Musician("6#Slash#Guns n' Roses"),
                    new Musician("7#Prince#The Revolution"),
                    new Musician("8#Eric Clapton#Cream"),
                    new Musician("9#Angus#Young"),
                    new Musician("10#John Frusciante#Red Hot Chili Peppers")
            });
            modelBuilder.Entity<Guitar>().HasData(new Guitar[]              
            {
                    new Guitar("1#Stratocaster#Sunburst#1#2#300000"),
                    new Guitar("2#Les Paul#Goldtop#4#6#350000"),
                    new Guitar("3#Telecaster#Butterscotch#1#7#270000"),
                    new Guitar("4#SG#Cherry#4#9#960000"),
                    new Guitar("5#Super Strato#Blue#2#3#250000"),
                    new Guitar("6#Flying V#White#4#10#500000"),
                    new Guitar("7#Acoustic#Natural#5#1#180000"),
                    new Guitar("8#Jazzmaster#Olympic White#1#4#400000"),
                    new Guitar("9#PRS Custom 24#Fire Red#3#5#700000"),
                    new Guitar("10#Stratocaster#Black#1#8#280000")
            });
            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1#Fender#1946#Andy Mooney#500000000"),
                new Brand("2#Ibanez#1908#Hoshino Gakki#80000000"),
                new Brand("3#PRS#1985#Jack Higginbotham#30000000"),
                new Brand("4#Gibson#1902#James 'JC' Curleigh#160000000"),
                new Brand("5#Martin#1833#Thomas Ripsam#100000000")
            });

        }
    }
}
