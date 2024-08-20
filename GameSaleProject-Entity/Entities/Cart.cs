using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Entities
{
    public class Cart
    {
        public string UserName { get; set; }
        public int GameId { get; set; }
        
        public decimal Price { get; set; }
    }
}
