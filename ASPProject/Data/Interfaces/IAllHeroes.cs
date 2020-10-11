using ASPProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Data.Interfaces
{
    public interface IAllHeroes
    {
        IEnumerable<Hero> Heroes { get; }
        public Hero GetHero(int IdHero);
    }
}
