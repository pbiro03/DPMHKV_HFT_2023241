using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Logic.Interfaces
{
    public interface IBrand
    {
        void Create(Brand item);
        void Delete(int id);
        Brand Read(int id);
        IEnumerable<Brand> ReadAll();
        void Update(Brand item);
    }
}
