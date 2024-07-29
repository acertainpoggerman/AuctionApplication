using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
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

        public Task<List<Bid>?> GetAllForListing(int? id, int count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
