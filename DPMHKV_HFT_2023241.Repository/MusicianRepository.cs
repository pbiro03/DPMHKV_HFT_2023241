﻿using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Repository
{
    public class MusicianRepository : AbstractRepository<Musician>, IRepository<Musician>
    {
        public MusicianRepository(GuitarDBContext ctx) : base(ctx)
        {
        }

        public override Musician Read(int id)
        {
            return ctx.Musicians.FirstOrDefault(x => x.MusicianID == id);
        }

        public override void Update(Musician item)
        {
            var old = Read(item.MusicianID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
