using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPProject.Controllers
{
    [Authorize(Roles = "admin")]

    public class SettingsController : Controller
    {
        public IAllHeroes AllHeroes;
        public IHeroesAtribute HeroesAtribute;
        IWebHostEnvironment _appEnvironment;

        public readonly HeroesContext _heroesContext;
        public SettingsController(HeroesContext heroesContext, IAllHeroes iAllHeroes, IHeroesAtribute iHeroesAtribute, IWebHostEnvironment appEnvironment)
        {
            _heroesContext = heroesContext;
            _appEnvironment = appEnvironment;
            AllHeroes = iAllHeroes;
            HeroesAtribute = iHeroesAtribute;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(string name, string decs, string AtributeName, IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                await using (var fileStream = new FileStream(_appEnvironment.WebRootPath+"/img/" + uploadedFile.FileName, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                await _heroesContext.Heroes.AddAsync(new Hero
                {
                    Name = name, decs = decs, img = "/img/" + uploadedFile.FileName,
                    Atribute = _heroesContext.Atribute.First(x => x.AtributeName == AtributeName)
                });
            }

            await _heroesContext.SaveChangesAsync();
            return RedirectToAction("List", "Heroes");
        }
        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(string name)
        {
            var hero = _heroesContext.Heroes.FirstOrDefault(x => x.Name == name);
            _heroesContext.Heroes.Remove(hero);
            _heroesContext.SaveChanges();
            return RedirectToAction("List", "Heroes");

        }
        [HttpGet]

        public IActionResult Alter()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("List", "Heroes");
        }

        [HttpPost]
        public IActionResult Alter(string fname, string name, string decs, string atributeName, string img = null)
        {

            var hero = _heroesContext.Heroes.FirstOrDefault(x => x.Name == fname);
            if (name != null)
                if (hero != null)
                    hero.Name = name;
            if (decs != null)
                if (hero != null)
                    hero.decs = decs;
            if (atributeName!= null)
                if (hero != null)
                    hero.Atribute = _heroesContext.Atribute.First(x => x.AtributeName == atributeName);
            if (img != null)
                if (hero != null)
                    hero.img = img;
            _heroesContext.SaveChanges();
                return RedirectToAction("List", "Heroes");

        }


       
    }
}