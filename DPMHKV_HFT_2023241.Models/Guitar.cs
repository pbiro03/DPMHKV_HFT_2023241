using System;
using System.ComponentModel.DataAnnotations;

namespace DPMHKV_HFT_2023241.Models
{
    public class Guitar
    {
        [Key]
        public int SerialNumberID { get; set; }
        public string Shape {  get; set; }
        public string Color { get; set; }
        public int YearOfProduction {  get; set; }
        public Brand Brand { get; set; } //foreign key obv
        public Guitar() { }

    }
}
