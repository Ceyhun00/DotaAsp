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
        public IAllHeroes AllHeroes;
        public IHeroesAtribute HeroesAtribute;

        public readonly HeroesContext HeroesContext;
        public HeroesController(HeroesContext heroesContext)
        {
            HeroesContext = heroesContext;
          
        }

        public ViewResult List()
        {

            ViewBag.Title = "Все герои";
            var obj = new HeroesListViewModel {Heroes = HeroesContext.Heroes};
            var a = HeroesContext.Heroes.Include(x => x.Atribute).ToList();
            obj.caterory = "Герои Dota2";
            return View(obj);
        }


        public ViewResult Io()
        {
            var obj = new DescriptionViewModel();
            var a = HeroesContext.Heroes.Include(x=>x.Atribute).First(x => x.Name == "Io");
            return View(a);
        }
           public ViewResult Slark()
        {
            var obj = new DescriptionViewModel();
            var a = HeroesContext.Heroes.First(x => x.Name == "Slark");
            return View(a);
        }

    }
}
