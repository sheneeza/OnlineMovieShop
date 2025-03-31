using ApplicationCore.Entities;
using ApplicationCore.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        private readonly MovieDbContext _context;

        public PurchaseRepository(MovieDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Purchase>> GetPurchasesByUserAsync(int userId)
        {
            return await _context.Purchases
                .Include(p => p.Movie)
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        
        public async Task<bool> IsMoviePurchasedByUserAsync(int movieId, int userId)
        {
            return await _context.Purchases
                .AnyAsync(p => p.MovieId == movieId && p.UserId == userId);
        }
    }
}