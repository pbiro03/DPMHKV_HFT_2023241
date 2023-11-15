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
        GuitarLogic logic;
        Mock<IRepository<Guitar>> mockGuitarRepo;


        [SetUp]
        public void Init()
        {
            mockGuitarRepo = new Mock<IRepository<Guitar>>();
            mockGuitarRepo.Setup(x => x.ReadAll()).Returns(new List<Guitar>()
            {
                new Guitar("1#Stratocaster#Sunburst#Fender#M2#300000"),
                    new Guitar("2#Les Paul#Goldtop#Gibson#M6#350000"),
                    new Guitar("3#Telecaster#Butterscotch#Fender#M7#270000"),
                    new Guitar("4#SG#Cherry#Gibson#M9#960000"),
                    new Guitar("5#Super Strato#Blue#Ibanez#M3#250000")
            }.AsQueryable());
            logic = new GuitarLogic(mockGuitarRepo.Object);
        }
        [Test]
        public void CountGuitarByBrandTest()
        {
            var actual = logic.CountGuitarsByBrand().ToList();
            var expected = new List<Guitar>()
            {

            };
        }
    }
}
