using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
	public class SystemRequirementViewModel
	{
		public int Id { get; set; }
		public string OS { get; set; }
		public bool IsMinimum { get; set; }
		public string SystemProcessor { get; set; }
		public byte SystemMemory { get; set; }
		public int Storage { get; set; }
		public string Graphics { get; set; }
		public int GameId { get; set; }
	}
}
