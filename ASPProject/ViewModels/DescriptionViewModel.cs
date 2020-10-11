using ASPProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.ViewModels
{
    public class DescriptionViewModel
    {
        public Hero Heroes { get; set; }
        public Atribute Atributes { get; set; }
        public Items Items { get; set; }
        public Clothes Clothes { get; set; }

        public Characteristics Characteristics { get; set; }



    }
}
