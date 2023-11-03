using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;
using DPMHKV_HFT_2023241.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Logic.Classes
{
    public class GuitarLogic:IGuitar
    {
        IRepository<Guitar> repo;

        public GuitarLogic(IRepository<Guitar> repo)
        { 
            this.repo = repo;
        }

        public void Create(Guitar item)
        {
            if (item.Price<0)
            {
                throw new ArgumentException("Price can not be negativ");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Guitar Read(int id)
        {
            var guitar = repo.Read(id);
            return guitar;

        }

        public IEnumerable<Guitar> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Guitar item)
        {
            repo.Update(item);
        }

        //following are the non-crud methods
        //többtáblás lekérdezés kell!!!!  --> kell csinálni majd még egy külön osztályt --> pl GuitarInfo
        
        public IEnumerable<GuitarInfo> CountGuitarsByBrand()
        {

            return from x in this.repo.ReadAll()
                   group x by x.Brand.BrandID into g
                   select new GuitarInfo
                   {
                       BrandName=g.Key,
                       //guitarcount=g.Count()
                   };
        }
        public IEnumerable<GuitarInfo> MusiciansWithExpensiveGuitar()
        {
            return from x in this.repo.ReadAll()
                   where x.Price > 300000
                   select new GuitarInfo
                   {

                   };
        }
        public IEnumerable<GuitarInfo> AVGPriceByBrands()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Brand.BrandID into g
                   select new GuitarInfo
                   {
                       BrandName = g.Key,
                       //AVGPrice= g.Average(t=>t.Price)
                   };


        }
        public IEnumerable<GuitarInfo> CountGuitarsByMusician()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Musician.MusicianID into g
                   select new GuitarInfo
                   {
                       BrandName = g.Key,
                       //guitarcount=g.Count
                   };
        }
        public IEnumerable<GuitarInfo> GuitarsInBands() //which guitar is in the registered bands
        {
            return from x in this.repo.ReadAll()
                   group x by x.Musician.BandName into g
                   select new GuitarInfo
                   {

                   };
        }

        public class GuitarInfo
        {
            public string BrandName;
            public string Shape;
            public string Color;
        }
    }
}
