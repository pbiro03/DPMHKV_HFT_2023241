using DPMHKV_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Logic.Interfaces
{
    public interface IMusician
    {
        void Create(Musician item);
        void Delete(int id);
        Musician Read(int id);
        IEnumerable<Musician> ReadAll();
        void Update(Musician item);
    }
}
