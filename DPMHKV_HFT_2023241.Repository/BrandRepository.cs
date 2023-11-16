using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Repository
{
    public class BrandRepository : AbstractRepository<Brand>, IRepository<Brand>
    {
        public BrandRepository(GuitarDBContext ctx) : base(ctx)
        {
        }

        public override Brand Read(int id)
        {
            return ctx.Brands.FirstOrDefault(x => int.Parse(x.BrandID) == id);
        }

        public override void Update(Brand item)
        {
            var old = Read(int.Parse(item.BrandID));
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
