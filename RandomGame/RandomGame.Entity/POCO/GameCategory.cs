using RandomGame.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RandomGame.Entity.POCO
{
    public class GameCategory:IBaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int GameID { get; set; }
        public int CategoryID { get; set; }
        public virtual Game Game { get; set; }
        public virtual Category Category { get; set; }
    }
}
