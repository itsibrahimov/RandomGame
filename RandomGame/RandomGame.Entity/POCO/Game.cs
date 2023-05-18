using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.POCO
{
    public class Game:BaseEntity
    {

        public string GameName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public virtual ICollection<GameCategory> GameCategory { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }
        public virtual Image Image { get; set; }
    }
}
