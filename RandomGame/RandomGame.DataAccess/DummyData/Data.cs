using RandomGame.DataAccess.Context;
using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.DataAccess.DummyData
{
    public static class Data
    {
        
        public static void DataInsert()
        {

            RandomGameDbContext db = new RandomGameDbContext();

            List<Game> games = new List<Game>() {

                new Game { GameName= "Mount & Blade II: Bannerlord",Description= "Strateji/Aksiyon RYO. Karakterini yarat ve diplomasi, zanaat ve ticaretle ilgilenirken, bir yandan da devasa bir orta çağ sandbox haritasında yeni topraklar fethet. Derin ve sezgisel dövüş sistemini kullanarak gerçek zamanlı büyük savaşlarda birliklerine önderlik et ve askerlerinle birlikte savaş.",Price=279.99m,Stock=50, },
                new Game { GameName= "Forza Horizon 5",Description= "Dünyanın en iyi araçlarında sınırsız, eğlenceli sürücülük aksɨyonuyla dolu Meksika'nın capcanlı açık dünya manzaralarını keşfedin. Hot Wheels Park'a gidip bugüne kadar tasarlanmış en zorlu pistleri deneyimleyin. Forza Horizon 5 oyunu gerekir, genişletme ayrı satılır.",Stock=50,Price= 359.40m },
                new Game{ GameName= "God of War",Description= "Olimpos Tanrılarından aldığı intikamın üzerinden yıllar geçen Kratos, artık İskandinav Tanrılarının ve canavarlarının diyarında sıradan bir insan olarak yaşıyor. Bu sert ve acımasız dünyada hayatta kalabilmek için savaşmak ve oğluna da aynısını öğretmek zorunda.",Price= 197.40m,Stock=50 },
                new Game { GameName= "Dying Light 2 Stay Human",Description= "Virüs kazandı ve medeniyet Karanlık Çağ'a geri döndü. İnsanlığın son yerleşkelerinden biri olan Şehir, yıkılmanın eşiğinde. Hayatta kalmak için çevikliğini ve dövüş yeteneklerini kullan ve dünyayı yeniden şekillendir. Seçimlerin herkesin kaderini belirleyecek.",Stock=50,Price=174.50m }
                };

            db.Game.AddRange(games);
            db.SaveChanges();

            List<Category> categories = new List<Category>()
            {
                new Category{ CategoryName=" Aksiyon"},
                new Category{CategoryName="Bağımsız Yapımcı"},
                new Category{CategoryName="RYO"},
                new Category {CategoryName="Simülasyon"},
                new Category{CategoryName="Strateji"},
                new Category {CategoryName="Macera"},
                new Category{CategoryName="Yarış"},
                new Category{CategoryName="Spor"}

            };

            db.Category.AddRange(categories);
            db.SaveChanges();

            List<GameCategory> gameCategories = new List<GameCategory>()
            {
                new GameCategory{GameID=1,CategoryID=1},
                 new GameCategory{GameID=1,CategoryID=2},
                  new GameCategory{GameID=1,CategoryID=3},
                  new GameCategory{GameID=1,CategoryID=4},
                  new GameCategory{GameID=1,CategoryID=5},

                   new GameCategory{GameID=2,CategoryID=1},
                    new GameCategory{GameID=2,CategoryID=6},
                     new GameCategory{GameID=2,CategoryID=7},
                      new GameCategory{GameID=2,CategoryID=8},
                       new GameCategory{GameID=2,CategoryID=4},

                        new GameCategory{GameID=3,CategoryID=1},
                         new GameCategory{GameID=3,CategoryID=2},
                          new GameCategory{GameID=3,CategoryID=6},

                          new GameCategory{GameID=4,CategoryID=1},
                         new GameCategory{GameID=4,CategoryID=2},
                          new GameCategory{GameID=4,CategoryID=6},
            };

            db.GameCategory.AddRange(gameCategories);
            db.SaveChanges();

            List<Image> ımages = new List<Image>()
            {
                new Image{GameID=1,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/261550/header.jpg?t=1671213711"},
                 new Image{GameID=1,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/261550/ss_569257e92fd31d58a6fe08053de637071b4518d3.600x338.jpg?t=1671213711"},

                 new Image{GameID=2,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/header.jpg?t=1677534139"},
                 new Image{GameID=2,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1551360/ss_3654a5988db68f9b47740f9f6a9299682c365599.600x338.jpg?t=1677534139"},

                 new Image{GameID=3,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1593500/header.jpg?t=1650554420"},
                 new Image{GameID=3,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/1593500/ss_1351cb512d008f7e47fc50b74197f4f8eb6f3419.600x338.jpg?t=1650554420"},

                 new Image{GameID=4,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/534380/header_alt_assets_15_turkish.jpg?t=1679476094"},
                 new Image{GameID=4,ImageURL="https://cdn.cloudflare.steamstatic.com/steam/apps/534380/ss_ff38bf9182b04020a92211be2ef2e59f14e59159.600x338.jpg?t=1679476094"},
            };
            db.Image.AddRange(ımages);
            db.SaveChanges();


        } 
    }
}
