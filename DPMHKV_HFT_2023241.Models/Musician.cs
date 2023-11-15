using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Musician
    {
        [Key]
        public string MusicianID {  get; set; }
        public string Name {  get; set; }      
        public string BandName {  get; set; }
        [NotMapped]
        public virtual ICollection<Guitar> Guitars { get; set; }
        public Musician()
        {
            Guitars = new HashSet<Guitar>();
        }

        public Musician(string line)
        {
            string[] split = line.Split('#');
            MusicianID = split[0];
            Name = split[1];
            BandName = split[2];
            Guitars = new HashSet<Guitar>();
        }
    }
}
