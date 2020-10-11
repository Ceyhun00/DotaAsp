using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using ASPProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Controllers
{

    public class HeroesController : Controller
    {
        public IAllHeroes _AllHeroes;
        public IHeroesAtribute _HeroesAtribute;

        public readonly HeroesContext _heroesContext;
        public HeroesController(HeroesContext heroesContext)
        {
            _heroesContext = heroesContext;
          
        }

        public ViewResult List()
        {

            ViewBag.Title = "Все герои";
            HeroesListViewModel obj = new HeroesListViewModel();
            obj.Heroes = _heroesContext.Heroes;
            var a = _heroesContext.Heroes.Include(x => x.Atribute).ToList();
            obj.caterory = "Герои Dota2";
            return View(obj);
        }


        public ViewResult Io()
        {
            DescriptionViewModel obj = new DescriptionViewModel();
            var a = _heroesContext.Heroes.Include(x=>x.Atribute).First(x => x.Name == "Io");
            return View(a);
        }
           public ViewResult Slark()
        {
            DescriptionViewModel obj = new DescriptionViewModel();
            var a = _heroesContext.Heroes.First(x => x.Name == "Slark");
            return View(a);
        }

    }
}
