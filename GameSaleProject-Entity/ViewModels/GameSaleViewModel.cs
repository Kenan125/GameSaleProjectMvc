using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class GameSaleViewModel
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsDiscountApplied { get; set; }
        public bool IsFullyRefunded { get; set; } = false;
        public DateTime CreatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public virtual List<GameSaleDetailViewModel> GameSaleDetails { get; set; }


        public virtual AppUser User { get; set; }


    }
}
