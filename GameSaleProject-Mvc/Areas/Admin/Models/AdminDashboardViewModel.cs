using GameSaleProject_Entity.ViewModels;

namespace GameSaleProject_Mvc.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public UserViewModel AdminProfile { get; set; }
        public int TotalGames { get; set; }
        public int TotalUsers { get; set; }
        public int TotalSales { get; set; }
        
        public decimal TotalRevenue { get; set; }
        public List<SalesByDateViewModel> SalesByDate { get; set; } = new List<SalesByDateViewModel>();
    }
    // Define a new class to hold date and revenue
    public class SalesByDateViewModel
    {
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
