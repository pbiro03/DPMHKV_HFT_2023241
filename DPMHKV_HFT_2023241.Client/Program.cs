using DPMHKV_HFT_2023241.Repository;
using System;
using System.Linq;

namespace DPMHKV_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GuitarDBContext ctx = new GuitarDBContext();
            var q1 = ctx.Guitars.Select(x => x.Color);
            var q2 = ctx.Brands.Select(x => x.NetWorth);
            var q3 = ctx.Musicians.Select(x => $"{x.Name} from {x.BandName}");

            ;

        }
    }
}
