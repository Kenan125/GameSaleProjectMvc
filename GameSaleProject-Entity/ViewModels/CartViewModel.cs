using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
    public class CartViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();

        public decimal TotalPrice
        {
            get
            {
                return Items.Sum(item => item.Price);
            }
        }
    }
}
