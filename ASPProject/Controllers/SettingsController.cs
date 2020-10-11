using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASPProject.Controllers
{
    [Authorize(Roles = "admin")]

    public class SettingsController : Controller
    {
        public IAllHeroes _AllHeroes;
        public IHeroesAtribute _HeroesAtribute;

        public readonly HeroesContext _heroesContext;
        public SettingsController(HeroesContext heroesContext, IAllHeroes iAllHeroes, IHeroesAtribute iHeroesAtribute)
        {
            _heroesContext = heroesContext;
            _AllHeroes = iAllHeroes;
            _HeroesAtribute = iHeroesAtribute;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public string Add(String name, string decs, string AtributeName, string img = null)
        {
            _heroesContext.Heroes.Add(new Hero { Name = name, decs = decs, img = img, Atribute = _heroesContext.Atribute.First(x => x.AtributeName == AtributeName) });
            _heroesContext.SaveChanges();
            return name;
        }
        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public string Delete(String name )
        {
            Hero hero = _heroesContext.Heroes.Where(x => x.Name == name).FirstOrDefault();
            _heroesContext.Heroes.Remove(hero);
            _heroesContext.SaveChanges();
            return $"Успешно удален герой {name}";

        }
        [HttpGet]

        public IActionResult Alter()
        {
            return View();
        }
        [HttpPost]
        public string Alter(String fname, String name, string decs, string AtributeName, string img = null)
        {

            Hero hero = _heroesContext.Heroes.Where(x => x.Name == fname).FirstOrDefault();
            if (name != null)
                hero.Name = name;
            if (decs != null)
               hero.decs = decs;
            if (AtributeName!= null)
                hero.Atribute= _heroesContext.Atribute.First(x => x.AtributeName == AtributeName);
            if (img != null)
                hero.img = img;
                _heroesContext.SaveChanges();
            return name;

        }


    }
}