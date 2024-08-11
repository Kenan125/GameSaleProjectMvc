using GameSaleProject_Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
    public class CustomerInvoiceViewModel
    {
        public CustomerViewModel customerViewModel { get; set; }
        public GameSaleViewModel GameSaleViewModel { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}
