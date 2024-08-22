﻿using GameSaleProject_DataAccess.Contexts;
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

        public async Task<List<GameSale>> GetUserPurchasesAsync(string userName)
        {
            return await _context.GameSales
                .Include(gs => gs.User) // Include the User to ensure it's loaded
                .Include(gs => gs.GameSaleDetails)
                    .ThenInclude(gsd => gsd.Game) // Ensure Game is loaded as well
                .Where(gs => gs.User.UserName == userName) // Now this should work
                .ToListAsync();
        }

    }
}
