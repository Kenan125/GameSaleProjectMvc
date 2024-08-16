﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class ImageViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string ImageUrl { get; set; }
        public string? ImageType { get; set; }
        public int GameId { get; set; }
        
    }
}
