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
        
        public IEnumerable<KeyValuePair<string,int>> CountGuitarsByBrand()
        {

            return from x in this.repo.ReadAll()
                   group x by x.Brand.BrandName into g
                   select new KeyValuePair<string,int>
                   (
                      g.Key,
                      g.Count()
                   );
        }
        public IEnumerable<Musician> MusiciansWithExpensiveGuitar()
        {
            return from x in this.repo.ReadAll()
                   where x.Price > 300000
                   group x by x.Musician.Name into g
                   select new Musician
                   {
                       Name = g.Key
                   };
        }
        public IEnumerable<KeyValuePair<string,double>> AVGPriceByBrands()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Brand.BrandName into g
                   select new KeyValuePair<string,double>
                   (
                        g.Key,g.Average(t=>t.Price)
                   );
        }
        public IEnumerable<KeyValuePair<string,int>> CountGuitarsByMusician()
        {
            return from x in this.repo.ReadAll()
                   group x by x.Musician.Name into g
                   select new KeyValuePair<string, int>
                   (
                       g.Key,g.Count()
                       );
                   
        }
        public IEnumerable<KeyValuePair<string,string>> GuitarsInBands() //which guitar is in the registered bands
        {
            return from x in this.repo.ReadAll()
                   select new KeyValuePair<string, string>
                   (x.Musician.BandName,x.Brand.BrandName
                       ) ;
                   
        }
    }
}
