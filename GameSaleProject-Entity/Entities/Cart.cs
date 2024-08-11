using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Entities
{
    public class Cart
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal GamePrice { get; set; }
    }
}
