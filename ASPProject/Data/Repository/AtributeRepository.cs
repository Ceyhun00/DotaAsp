using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Data.Repository
{
    public class AtributeRepository : IHeroesAtribute
    {
        public readonly HeroesContext heroesContext;
        public AtributeRepository(HeroesContext heroesContext)
        {
            this.heroesContext = heroesContext;
        }
        public IEnumerable<Atribute> AllAtributes => heroesContext.Atribute.Include(x=>x.Heroes);
    }
}
