using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Mvc.Areas.User.Models
{
    public class PurchaseHistoryViewModel
    {
        public int OrderId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<PurchasedGameViewModel> PurchasedGames { get; set; }
    }
}
