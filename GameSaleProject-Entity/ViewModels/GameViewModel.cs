using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class GameViewModel
	{
        public int Id { get; set; }
        public string GameName { get; set; }


        public string Description { get; set; }


        public int Discount { get; set; }


        public decimal Price { get; set; }

        public string Developer { get; set; }


        public int PublisherId { get; set; }


        public int CategoryId { get; set; }

        public string Platform { get; set; }


    }
}
