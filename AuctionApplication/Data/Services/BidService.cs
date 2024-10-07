using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Data.Services
{
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext _context;

        public BidService(ApplicationDbContext context)
        {
            _context = context;
        }


        public IQueryable<Bid> GetAll()
        {
            var applicationDbContext = _context.Bids.Include(b => b.User);
            return applicationDbContext;
        }

        public async Task Add(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bid>?> GetBidsForListing(int listingId, int count = 10)
        {
            var bids = await _context.Bids
                .Where(b => b.ListingId == listingId)
                .Include(b => b.User)
                .OrderByDescending(b => b.Price)
                .Take(count)
                .ToListAsync();

            return bids;
        }
    }
}
