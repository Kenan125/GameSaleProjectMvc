﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Entity.ViewModels
{
    public class CartItemViewModel
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public decimal Price { get; set; }
    }
}
