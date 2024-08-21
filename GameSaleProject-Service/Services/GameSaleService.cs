using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class GameSaleService : IGameSaleService
    {
        private readonly GameSaleProjectDbContext _context;

        public GameSaleService(GameSaleProjectDbContext context)
        {
            _context = context;
        }

        public async Task CreateGameSaleAsync(GameSale gameSale)
        {
            _context.GameSales.Add(gameSale);
            await _context.SaveChangesAsync();
        }

        public GameSale GetGameSaleById(int gameSaleId)
        {
            return _context.GameSales.Include(gs => gs.GameSaleDetails)
                                      .ThenInclude(gsd => gsd.Game)
                                      .FirstOrDefault(gs => gs.Id == gameSaleId);
        }
    }
}
