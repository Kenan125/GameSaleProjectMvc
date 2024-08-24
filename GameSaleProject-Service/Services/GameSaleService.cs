using AutoMapper;
using GameSaleProject_DataAccess.Contexts;
using GameSaleProject_Entity.Entities;
using GameSaleProject_Entity.Interfaces;
using GameSaleProject_Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameSaleProject_Service.Services
{
    public class GameSaleService : IGameSaleService
    {
        private readonly GameSaleProjectDbContext _context;
        private readonly IMapper _mapper;

        public GameSaleService(GameSaleProjectDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateGameSaleAsync(GameSale gameSale)
        {
            _context.GameSales.Add(gameSale);
            await _context.SaveChangesAsync();
        }

        public async Task<GameSaleViewModel> GetGameSaleByIdAsync(int gameSaleId)
        {
            var gameSale = await _context.GameSales
                .Include(gs => gs.GameSaleDetails)
                .ThenInclude(gsd => gsd.Game)
                .FirstOrDefaultAsync(gs => gs.Id == gameSaleId);

            return gameSale == null ? null : _mapper.Map<GameSaleViewModel>(gameSale);
        }

        public async Task<List<GameSaleViewModel>> GetUserPurchasesAsync(string userName)
        {
            var gameSales = await _context.GameSales
                .Include(gs => gs.User)
                .Include(gs => gs.GameSaleDetails)
                    .ThenInclude(gsd => gsd.Game)
                    .ThenInclude(g => g.Images)
                .Where(gs => gs.User.UserName == userName)
                .ToListAsync();

            return _mapper.Map<List<GameSaleViewModel>>(gameSales);
        }

        public async Task RefundGameSaleAsync(int gameSaleId, int? gameSaleDetailId = null)
        {
            var gameSale = await GetGameSaleByIdAsync(gameSaleId);
            if (gameSale == null) return;

            if (gameSaleDetailId.HasValue)
            {
                var gameSaleDetail = gameSale.GameSaleDetails.FirstOrDefault(gsd => gsd.Id == gameSaleDetailId.Value);
                if (gameSaleDetail != null && !gameSaleDetail.IsRefunded)
                {
                    gameSaleDetail.IsRefunded = true;
                }
            }
            else
            {
                foreach (var detail in gameSale.GameSaleDetails)
                {
                    detail.IsRefunded = true;
                }
                gameSale.IsFullyRefunded = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
