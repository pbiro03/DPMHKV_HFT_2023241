using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;
using DPMHKV_HFT_2023241.Repository;
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
    }
}
