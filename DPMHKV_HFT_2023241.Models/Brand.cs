using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        public int YearOfFoundation {  get; set; }
        public string CEO { get; set;}
        public int NetWorth {  get; set;}
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Guitar> Guitars {  get; set; }
        public Brand()
        {
            Guitars = new HashSet<Guitar>();
        }

        public Brand(string line)
        {
            string[] split = line.Split('#');
            BrandID = int.Parse(split[0]);
            BrandName = split[1];
            YearOfFoundation = int.Parse(split[2]);
            CEO = split[3];
            NetWorth = int.Parse(split[4]);
            Guitars = new HashSet<Guitar>();
        }
    }
}
