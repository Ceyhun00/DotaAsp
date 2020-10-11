using ASPProject.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProject.Data
{
    public class DbObjects
    {
        public static void Initial(HeroesContext content)
        {
            if (!content.Atribute.Any())
            {

                content.Atribute.AddRange(
                new Atribute { AtributeName = "Agility", decs = "Ловкач получает броню,скорость атаки и урон за каждую единицу", },
                new Atribute { AtributeName = "Strengh", decs = "Силовик, Получает здоровье и урон за каждую единицу", },
                new Atribute { AtributeName = "Intelligence", decs = "Интовик получает ману, урон и урон от способностей за каждую единицу", }
                   );
                content.SaveChanges();
            }
            if (!content.Atribute.Any())
            {

                content.Atribute.AddRange(
                new Atribute { AtributeName = "Agility", decs = "Ловкач получает броню,скорость атаки и урон за каждую единицу", },
                new Atribute { AtributeName = "Strengh", decs = "Силовик, Получает здоровье и урон за каждую единицу", },
                new Atribute { AtributeName = "Intelligence", decs = "Интовик получает ману, урон и урон от способностей за каждую единицу", }
                   );
                content.SaveChanges();
            }

            if (!content.Heroes.Any())
            {
                content.Heroes.AddRange(
                         new Hero { Name = "Slark", decs = "Ловкач Ескейпер", img = "/img/slark_icon.png", Atribute = content.Atribute.First(x => x.AtributeName == "Agility") },
                         new Hero { Name = "Io", decs = "Силовик хиллер", img = "/img/io_icon.png", Atribute = content.Atribute.First(x => x.AtributeName == "Strengh") },
                         new Hero { Name = "Lina", decs = "Интовик DMGДиллер", img = "/img/Lina_icon.png", Atribute = content.Atribute.First(x => x.AtributeName == "Intelligence" )});
                content.SaveChanges();
            }
            if (!content.Items.Any())
            {
                content.Items.Add(new Items { First_item = "ao", Second_item = "ad", Third_item = "nana", Forth_item = "nono", Fifth_item = "5", Sixth_item = "6", Heroes = content.Heroes.First(x => x.Name == "Slark") });
                content.SaveChanges();
            }
            
           
            content.SaveChanges();
            } 
    }   
}
