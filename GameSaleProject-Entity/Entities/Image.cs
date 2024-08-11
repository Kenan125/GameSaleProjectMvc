using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.Entities
{
    public class Image : BaseEntity
	{
        
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

    }
}
