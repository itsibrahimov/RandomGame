using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RandomGame.BusinessLogicLayer.Abstract;
using RandomGame.BusinessLogicLayer.Concrete;
using RandomGame.DataAccess.Abstract;
using RandomGame.DataAccess.Concrete.ADONET;
using RandomGame.DataAccess.Concrete.EntityFramework;
using RandomGame.DataAccess.Context;
using RandomGame.DataAccess.DummyData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomGame.API
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
            services.AddControllers();
            services.AddCors(x =>
            {
                x.AddPolicy("RandomGameIonic", c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowCredentials();
                    c.WithOrigins("http://localhost:8100");

                });
            });

            services.AddSwaggerGen(
                f => {

                    f.SwaggerDoc("RandomGameSwagger", new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Random Game Swagger Api Document",
                        Version = "v1.0"
                        
                    });
                    
                    }
                );
            //Dependency Injection

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
            //Data.DataInsert();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(
                x => { x.SwaggerEndpoint("/swagger/RandomGameSwagger/swagger.json", "Swagger"); }
                );
            app.UseHttpsRedirection();
            app.UseCors("RandomGameIonic");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Game}/{action=GetGames}/{id?}"
                    );
            });
        }
    }
}
