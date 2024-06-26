﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DPMHKV_HFT_2023241.Models
{
    public class Musician
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicianID {  get; set; }
        public string Name {  get; set; }      
        public string BandName {  get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Guitar> Guitars { get; set; }
        public Musician()
        {
            Guitars = new HashSet<Guitar>();
        }

        public Musician(string line)
        {
            string[] split = line.Split('#');
            MusicianID = int.Parse(split[0]);
            Name = split[1];
            BandName = split[2];
            Guitars = new HashSet<Guitar>();
        }
        public override bool Equals(object obj)
        {
            Musician b = obj as Musician;
            if (b == null)
            {
                return false;
            }
            else
            {
                return this.MusicianID == b.MusicianID
                    && this.Name == b.Name
                    && this.BandName == b.BandName;
            }
        }
    }
}
