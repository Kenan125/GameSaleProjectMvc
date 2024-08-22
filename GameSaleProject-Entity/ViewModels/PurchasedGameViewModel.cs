using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
    public class PurchasedGameViewModel
    {
        public string GameName { get; set; }
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string CoverImageUrl { get; set; } // If you have images
    }
}
