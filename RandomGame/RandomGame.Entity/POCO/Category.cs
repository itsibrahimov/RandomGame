using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.POCO
{
    public class Category:BaseEntity
    {

        public string CategoryName { get; set; }
        public virtual ICollection<GameCategory> GameCategory { get; set; }
    }
}
