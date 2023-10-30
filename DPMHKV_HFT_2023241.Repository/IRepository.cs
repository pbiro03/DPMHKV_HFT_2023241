using Castle.DynamicProxy.Generators.Emitters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ReadAll();
        void Create(T item);
        T Read(int id);
        void Update(T item);
        void Delete(int id);
    }

}
