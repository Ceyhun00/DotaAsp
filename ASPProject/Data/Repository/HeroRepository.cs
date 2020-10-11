using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Data.Repository
{
    public class HeroRepository : IAllHeroes
    {
        public  HeroesContext heroesContext;
        

        public HeroRepository(HeroesContext heroesContext)
        {
            this.heroesContext = heroesContext;
        }
 
        public IEnumerable<Hero> Heroes=> heroesContext.Heroes.Include(x => x.Atribute);

        public Hero GetHero(int HeroId) => heroesContext.Heroes.Where(x=>x.Id==HeroId).FirstOrDefault();
    }
}
