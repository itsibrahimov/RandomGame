using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.BusinessLogicLayer.Concrete;
using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Concrete.EntityFramework;
using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomGame.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy(name: "RandomGameAPI", builder =>
            {
                builder.WithOrigins("https://localhost:44353").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
            }));
            services.AddControllersWithViews();
            services.AddIdentity<AppUser, AppRole>(x =>
                {
                    x.Password.RequireDigit = false;
                    x.Password.RequireNonAlphanumeric = false;
                    x.Password.RequireUppercase = false;
                    x.Password.RequireLowercase = false;
                    x.Password.RequiredLength = 4;
                    x.User.RequireUniqueEmail = true;
                }).AddEntityFrameworkStores<RandomGameDbContext>();
            services.AddScoped<IGameDAL, EfGame>();
            services.AddScoped<ICategoryDAL, EfCategory>();
            services.AddScoped<ICartDAL, EfCart>();
            services.AddScoped<IGameCategoryDAL, EfGameCategory>();
            services.AddScoped<IimageDAL, EfImage>();

            services.AddScoped<IGameService, GameManager>();
            services.AddScoped<IGameCategoryService, GameCategoryManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IImageService, ImageManager>();
            services.AddDbContext<RandomGameDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("RandomGameAPI");
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name:"admin",
                    areaName:"Admin",
                    pattern:"admin/{controller=AdminAccount}/{action=AdminLogin}/{id?}"
                    );
            });
        }
    }
}
