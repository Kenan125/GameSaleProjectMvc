using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class PublisherViewModel
	{
		public int Id { get; set; }
        [Required(ErrorMessage = "Publisher Name is required")]
        public string Name { get; set; }

        
        //public int? UserId { get; set; }
        public UserViewModel User { get; set; }
        public ICollection<GameViewModel> Games { get; set; } = new List<GameViewModel>();
    }
}
