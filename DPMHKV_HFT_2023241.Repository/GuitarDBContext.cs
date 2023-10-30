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
                //string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\guitar.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                //optionsBuilder.UseLazyLoadingProxies().UseSqlServer(conn);
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
                    new Musician("M1#John Lennon#The Beatles"),
                    new Musician("M2#Jimi Hendrix#The Jimi Hendrix Experience"),
                    new Musician("M3#Lukács Péter#Bikini"),
                    new Musician("M4#John Mayer#The John Mayer Experience"),
                    new Musician("M5#Brian May#Queen"),
                    new Musician("M6#Slash#Guns n' Roses"),
                    new Musician("M7#Prince#The Revolution"),
                    new Musician("M8#Eric Clapton#Cream"),
                    new Musician("M9#Angus#Young"),
                    new Musician("M10#John Frusciante#Red Hot Chili Peppers")
            });
            modelBuilder.Entity<Guitar>().HasData(new Guitar[]              
            {
                    new Guitar("1#Stratocaster#Sunburst#Fender#M2"),
                    new Guitar("2#Les Paul#Goldtop#Gibson#M6"),
                    new Guitar("3#Telecaster#Butterscotch#Fender#M7"),
                    new Guitar("4#SG#Cherry#Gibson#M9"),
                    new Guitar("5#Super Strato#Blue#Ibanez#M3"),
                    new Guitar("6#Flying V#White#Gibson#M10"),
                    new Guitar("7#Acoustic#Natural#Martin#M1"),
                    new Guitar("8#Jazzmaster#Olympic White#Fender#M4"),
                    new Guitar("9#PRS Custom 24#Fire Red#PRS#M5"),
                    new Guitar("10#Stratocaster#Black#Fender#M8")
            });
            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("Fender#1946#Andy Mooney#500000000"),
                new Brand("Ibanez#1908#Hoshino Gakki#80000000"),
                new Brand("PRS#1985#Jack Higginbotham#30000000"),
                new Brand("Gibson#1902#James 'JC' Curleigh#160000000"),
                new Brand("Martin#1833#Thomas Ripsam#100000000")
            });

        }
    }
}
