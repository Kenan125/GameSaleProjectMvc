using GameSaleProject_Entity.Entities;

namespace GameSaleProject_Entity.ViewModels
{
    public class UserInvoiceViewModel
    {
        public UserViewModel customerViewModel { get; set; }
        public GameSaleViewModel GameSaleViewModel { get; set; }
        public List<CartItem> cartItems { get; set; }
    }
}
