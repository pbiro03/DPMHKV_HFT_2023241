﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DPMHKV_HFT_2023241.Models
{
    public class Guitar
    {
        [Key]
        public int SerialNumberID { get; set; }
        public string Shape { get; set; }
        public string Color { get; set; }
        public int YearOfProduction { get; set; }
        public string BrandID {  get; set; }

        //[ForeignKey(nameof(Brand))]
        public virtual Brand Brand { get; set; }

        //[ForeignKey(nameof(Musician))]
        public string MusicianID {  get; set; }
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
            YearOfProduction = int.Parse(split[3]);
            BrandID = split[4];
            MusicianID = split[5];
        }
    }
}
