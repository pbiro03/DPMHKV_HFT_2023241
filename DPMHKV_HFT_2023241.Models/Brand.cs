using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Brand
    {
        [Key]
        public string CompanyID { get; set; }
        public int YearOfFoundation {  get; set; }
        public string CEO { get; set;}
        public int NetWorth {  get; set;}
        public Brand()
        {
            
        }
    }
}
