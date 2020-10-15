using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
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
            AllHeroes = iAllHeroes;
            HeroesAtribute = iHeroesAtribute;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<string> AddAsync(string name, string decs, string AtributeName, IFormFile uploadedFile)
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
            return name;
        }
        [HttpGet]

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public string Delete(String name)
        {
            Hero hero = _heroesContext.Heroes.FirstOrDefault(x => x.Name == name);
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