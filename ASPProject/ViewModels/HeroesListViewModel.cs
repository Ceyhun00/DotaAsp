using ASPProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.ViewModels
{
    public class HeroesListViewModel
    {
        public IEnumerable<Hero> Heroes { get; set; }
        public string caterory { get; set; }
        public IEnumerable<Hero> Atributes { get; set; }     
    }
}
