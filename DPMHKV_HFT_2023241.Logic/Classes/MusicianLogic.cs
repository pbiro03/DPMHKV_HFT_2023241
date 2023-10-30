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
    public class MusicianLogic:IMusician
    {
        IRepository<Musician> repo;

        public MusicianLogic(IRepository<Musician> repo)
        {
            this.repo = repo;
        }

        public void Create(Musician item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Musician Read(int id)
        {
            var musician = repo.Read(id);
            return musician;

        }

        public IEnumerable<Musician> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Musician item)
        {
            repo.Update(item);
        }
    }
}
