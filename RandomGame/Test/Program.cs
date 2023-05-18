using RandomGame.Entity.POCO;
using System;
using RandomGame.DataAccess.Concrete;
using RandomGame.DataAccess.Concrete.ADONET;
using RandomGame.DataAccess.Concrete.EntityFramework;
using RandomGame.DataAccess.Context;
using RandomGame.BusinessLogicLayer.Concrete;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Game game = new Game() { GameName = "DenemeAdo3", Price = 540, Description = "Test Açıklaması Ado", Stock = 52 };
            AdoGame ado = new AdoGame();
            
            RandomGameDbContext db = new RandomGameDbContext();
            
           
            //EfGame efGame = new EfGame(db);
            bool sonuc = ado.Add(game);

            if (sonuc)
            {
                Console.WriteLine("Oyun Eklendi");
            }
            else
            {
                Console.WriteLine("Oyun Eklenemedi");
            }
            Console.ReadLine();
           
            
        }
    }
}
