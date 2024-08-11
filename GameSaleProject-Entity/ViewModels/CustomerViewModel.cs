using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class CustomerViewModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string ProfilePicture { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
	}
}
