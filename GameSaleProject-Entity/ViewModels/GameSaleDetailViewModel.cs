using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class GameSaleDetailViewModel
	{
		public int Id { get; set; }
		public int GameSaleId { get; set; }
		public int GameId { get; set; }
		public decimal UnitPrice { get; set; }
        public bool IsRefunded { get; set; }




    }
}
