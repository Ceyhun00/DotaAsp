using ASPProject.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPProject.Data.Models
{
    
    public partial class Hero 
    {

        public int Id { get; set; }

        [StringLength(200)]
        public string decs { get; set; }

        [StringLength(200)]
        public string img { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        public  Atribute Atribute { get; set; }
        public  ICollection<Characteristics> Characteristics { get; set; }
        public  ICollection<Clothes> Clothes { get; set; }
        public  ICollection<Items> Items { get; set; }

    }
}
