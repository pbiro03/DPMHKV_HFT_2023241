﻿using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Logic.Interfaces
{
    public interface IGuitar
    {
        void Create(Guitar item);
        void Delete(int id);
        Guitar Read(int id);
        IEnumerable<Guitar> ReadAll();
        void Update(Guitar item);
        IEnumerable<Musician> MusiciansWithExpensiveGuitar();
        IEnumerable<KeyValuePair<string, int>> CountGuitarsByBrand();
        IEnumerable<KeyValuePair<string, double>> AVGPriceByBrands();
        IEnumerable<KeyValuePair<string, int>> CountGuitarsByMusician(); 
        IEnumerable<KeyValuePair<string, string>> GuitarsInBands();
    }
}
