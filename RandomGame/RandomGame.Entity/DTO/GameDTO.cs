using RandomGame.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomGame.Entity.DTO
{
	public class GameDTO
	{
		public int GameID { get; set; }
		public string GameName { get; set; }
		public int Stock { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public List<Image> Images { get; set; }
	}
}
