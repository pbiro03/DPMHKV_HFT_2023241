using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Brand
    {
        [Key]
        public string BrandID { get; set; }
        public int YearOfFoundation {  get; set; }
        public string CEO { get; set;}
        public int NetWorth {  get; set;}
        [NotMapped]
        public virtual ICollection<Guitar> Guitars {  get; set; }
        public Brand()
        {
            Guitars = new HashSet<Guitar>();
        }

        public Brand(string line)
        {
            string[] split = line.Split('#');
            BrandID = split[0];
            YearOfFoundation = int.Parse(split[1]);
            CEO = split[2];
            NetWorth = int.Parse(split[3]);
            Guitars = new HashSet<Guitar>();
        }
    }
}
