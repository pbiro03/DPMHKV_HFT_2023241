using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DPMHKV_HFT_2023241.Models
{
    public class Guitar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SerialNumberID { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public int BrandID {  get; set; }

        //[ForeignKey(nameof(Brand))]
        [NotMapped]
        public virtual Brand Brand { get; set; }

        //[ForeignKey(nameof(Musician))]
        public int MusicianID {  get; set; }
        [NotMapped]
        public virtual Musician Musician{ get; set; }
        
        
        public Guitar() 
        {
            
        }

        public Guitar(string line)
        {
            string[] split = line.Split('#');
            SerialNumberID = int.Parse(split[0]);
            Shape = split[1];
            Color = split[2];
            BrandID = int.Parse(split[3]);
            MusicianID = int.Parse(split[4]);
            Price = int.Parse(split[5]);
        }
    }
}
