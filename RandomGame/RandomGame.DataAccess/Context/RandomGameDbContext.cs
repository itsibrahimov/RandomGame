using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RandomGame.Entity.Mappings;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.Context
{
    public class RandomGameDbContext:IdentityDbContext<AppUser,AppRole,int>
    {
        public RandomGameDbContext()
        {

        }
        public RandomGameDbContext(DbContextOptions<RandomGameDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=RandomGameDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameCategory>().HasKey(x => new { x.CategoryID, x.GameID });
            builder.ApplyConfiguration(new GameMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.Entity<AppRole>().HasData(
                new AppRole() { Id=1,Name="UserApp",NormalizedName="USERAPP"},
                new AppRole() { Id=2,Name="Admin",NormalizedName="ADMIN"}
                );

            base.OnModelCreating(builder);
        }
        public DbSet<Game> Game { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<GameCategory> GameCategory { get; set; }
        public DbSet<Image> Image { get; set; }
        public DbSet<Cart> Cart { get; set; }
    }
}
