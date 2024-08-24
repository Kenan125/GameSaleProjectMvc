﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class UserViewModel
	{
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }		
		public string? Email { get; set; }
		public string? UserName { get; set; }		
		public string? PhoneNumber { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
