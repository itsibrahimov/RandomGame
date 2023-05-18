using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.POCO
{
    public class Image:BaseEntity
    {
        public int GameID { get; set; }
        public string ImageURL { get; set; }
        public ICollection<Game> Game { get; set; }
    }
}
