﻿using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Repository
{
    public class BrandRepository : AbstractRepository<Guitar>, IRepository<Guitar>
    {
        public BrandRepository(GuitarDBContext ctx) : base(ctx)
        {
        }

        public override Guitar Read(int id)
        {
            return ctx.Guitars.FirstOrDefault(x => x.SerialNumberID == id);
        }

        public override void Update(Guitar item)
        {
            var old = Read(item.SerialNumberID);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
