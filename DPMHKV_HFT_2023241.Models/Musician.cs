using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Musician
    {
        [Key]
        public string PersonalID {  get; set; }
        public string Name {  get; set; }
        public string Instrument { get; set; } //this will be a foreign key which references SerialNumber
        public string BandName {  get; set; }
        public Musician()
        {
            
        }
    }
}
