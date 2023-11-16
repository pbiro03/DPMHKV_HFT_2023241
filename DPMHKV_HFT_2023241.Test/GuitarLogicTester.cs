using DPMHKV_HFT_2023241.Logic.Classes;
using DPMHKV_HFT_2023241.Models;
using DPMHKV_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DPMHKV_HFT_2023241.Test
{
    [TestFixture]
    public class GuitarLogicTester
    {
        GuitarLogic guitarLogic;
        MusicianLogic musicianLogic;
        BrandLogic brandLogic;
        Mock<IRepository<Guitar>> mockGuitarRepo;
        Mock<IRepository<Musician>> mockMusicianRepo;
        Mock<IRepository<Brand>> mockBrandRepo;


        [SetUp]
        public void Init()
        {
            mockGuitarRepo = new Mock<IRepository<Guitar>>();
            var guitars = new List<Guitar>()
            {
                new Guitar("1#Stratocaster#Sunburst#Fender#M2#300000"),
                new Guitar("3#Telecaster#Butterscotch#Fender#M7#270000"),
                new Guitar("5#Super Strato#Blue#Ibanez#M3#250000"),
                new Guitar("2#Les Paul#Goldtop#Gibson#M6#350000"),

            }.AsQueryable();

            mockMusicianRepo = new Mock<IRepository<Musician>>();
            var musicians = new List<Musician>()
            {
                new Musician("M1#John Lennon#The Beatles"),
                new Musician("M2#Jimi Hendrix#The Jimi Hendrix Experience"),
                new Musician("M3#Lukács Péter#Bikini"),
            }.AsQueryable();
            var brands = new List<Brand>()
            {
                new Brand("Fender#1946#Andy Mooney#500000000"),
                new Brand("Ibanez#1908#Hoshino Gakki#80000000"),
                new Brand("Gibson#1902#James 'JC' Curleigh#160000000"),
            };
            guitars.ElementAt(0).Musician = musicians.ElementAt(2);
            guitars.ElementAt(0).Brand = brands[0];
            guitars.ElementAt(1).Musician = musicians.ElementAt(1);
            guitars.ElementAt(1).Brand = brands[0];
            guitars.ElementAt(2).Musician = musicians.ElementAt(0);
            guitars.ElementAt(2).Brand = brands[1];
            guitars.ElementAt(3).Musician = musicians.ElementAt(2);
            guitars.ElementAt(3).Brand = brands[2];

            guitarLogic = new GuitarLogic(mockGuitarRepo.Object);
            mockGuitarRepo.Setup(x => x.ReadAll()).Returns(guitars);

            musicianLogic = new MusicianLogic(mockMusicianRepo.Object);
            mockMusicianRepo.Setup(t => t.ReadAll()).Returns(musicians);
        }
        [Test]
        public void CountGuitarByBrandTest()
        {
            var actual = guitarLogic.CountGuitarsByBrand().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Fender",2),
                new KeyValuePair<string, int>("Ibanez", 1),
                new KeyValuePair<string, int>("Gibson", 1),
            }.ToList();
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void AVGPriceByBrands()
        {
            var actual = guitarLogic.AVGPriceByBrands().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Fender",285000),
                new KeyValuePair<string, int>("Ibanez", 250000),
                new KeyValuePair<string, int>("Gibson", 350000),
            }.ToList();
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void CountGuitarsByMusicianTest()
        {
            var actual = guitarLogic.CountGuitarsByMusician().ToList();
            var expected = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Lukács Péter",2),
                new KeyValuePair<string, int>("Jimi Hendrix",1),
                new KeyValuePair<string, int>("John Lennon",1),
            }.ToList();
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void GuitarsInBandsTest()
        {
            var actual = guitarLogic.GuitarsInBands().ToList();
            var expected = new List<KeyValuePair<string, string>>()
            {
                 new KeyValuePair<string, string>("Bikini","Fender"),
                 new KeyValuePair<string, string>("The Jimi Hendrix Experience","Fender"),
                 new KeyValuePair<string, string>("The Beatles","Ibanez"),
                 new KeyValuePair<string, string>("Bikini","Gibson")

            }.ToList();
            CollectionAssert.AreEqual(actual, expected);
        }
        [Test]
        public void MusiciansWithExpensiveGuitarTest()
        {
            var actual = guitarLogic.MusiciansWithExpensiveGuitar().ToList();
            var expected = new List<Musician>()
            {
                new Musician(){Name="Lukács Péter"},
            };
            Assert.That(actual[0].Equals(expected[0]));
        }
        [Test]
        public void CreateGuitarWithCorrectInputTest()
        {
            var guitar = new Guitar("8#Stratocaster#Black#Fender#M2#600000");

            guitarLogic.Create(guitar);

            mockGuitarRepo.Verify(t => t.Create(guitar), Times.Once);
        }
        [Test]
        public void CreateGuitarWithWrongInputTest()
        {
            var guitar = new Guitar("8#Stratocaster#Black#Fender#M2#-700");
            try
            {
                guitarLogic.Create(guitar);
            }
            catch { }

            mockGuitarRepo.Verify(t => t.Create(guitar), Times.Never);
        }
        [Test]
        public void CreateMusicianWithCorrectInputTest()
        {
            var musician = new Musician("M5#Brian May#Queen");
            musicianLogic.Create(musician);
            mockMusicianRepo.Verify(t => t.Create(musician), Times.Once);
        }
        [Test]
        public void CreateMusicianWithWrongInputTest1()
        {
            var musician = new Musician("M5#Brian May#Q");
            try
            {
                musicianLogic.Create(musician);
            }
            catch { }
            mockMusicianRepo.Verify(t=>t.Create(musician), Times.Never);
        }
        [Test]
        public void CreateMusicianWithWrongInputTest2() 
        {
            var musician = new Musician("M5#May#Queen");
            try { musicianLogic.Create(musician); }
            catch { }
            mockMusicianRepo.Verify(t => t.Create(musician), Times.Never);
        }

    }
}
