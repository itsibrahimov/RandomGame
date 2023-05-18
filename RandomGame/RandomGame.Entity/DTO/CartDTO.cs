using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.DTO
{
    public class CartDTO
    {
        public bool Active { get; set; }
        public bool Deleted { get; set; }
        public int UserId { get; set; }
        public int GameId { get; set; }
        public int Quantity { get; set; }
        public string GameName { get; set; }
        public string ImageURl { get; set; }
        public decimal Price { get; set; }
    }
}
