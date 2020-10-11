using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ASPProject.Data.Interfaces;
using ASPProject.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using ASPProject.Data.Repository;
using ASPProject.Data;
using System.Security.Claims;

namespace ASPProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = ".MyApp.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(3600);
                options.Cookie.IsEssential = true;
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<HeroesContext>(x => x.UseSqlServer(connection));
            services.AddTransient<IAllHeroes, HeroRepository>();
            services.AddTransient<IHeroesAtribute, AtributeRepository>();
            services.AddMvc();
            services.AddMvcCore();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                       options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                   });
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();   // добавляем механизм работы с сессиями
 

            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация        
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc(routes =>
            {
                routes.MapRoute("View", "{controller=Heroes}/{action=List}");
            });
            using (var scope = app.ApplicationServices.CreateScope())
            {
                HeroesContext content = scope.ServiceProvider.GetRequiredService<HeroesContext>();
                DbObjects.Initial(content);
            }
        }
    }
}
