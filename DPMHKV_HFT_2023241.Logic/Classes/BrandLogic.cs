using DPMHKV_HFT_2023241.Logic.Interfaces;
using DPMHKV_HFT_2023241.Models;
using DPMHKV_HFT_2023241.Repository;
using System;
using System.Collections.Generic;

namespace DPMHKV_HFT_2023241.Logic.Classes
{
    public class BrandLogic:IBrand
    {
        IRepository<Brand> repo;

        public BrandLogic(IRepository<Brand> repo)
        {
            this.repo = repo;
        }

        public void Create(Brand item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Brand Read(int id)
        {
            var brand = repo.Read(id);
            return brand;

        }

        public IEnumerable<Brand> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Brand item)
        {
            repo.Update(item);
        }
    }
}
