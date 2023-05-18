using RandomGame.Entity.POCO;
using System.Collections.Generic;

namespace RandomGame.MVC.Models
{
	public class GameModel
	{
		public int GameID { get; set; }
		public string GameName { get; set; }
		public int Stock { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public List<Image> Images { get; set; }
	}
}
