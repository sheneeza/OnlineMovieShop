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

        public async Task<IEnumerable<Movie>> GetMoviesPurchasedByUser(int userId)
        {
            return await _context.Purchases
                .Where(p => p.UserId == userId)
                .Include(p => p.Movie)
                .Select(p => p.Movie)
                .ToListAsync();
        }
    }
}