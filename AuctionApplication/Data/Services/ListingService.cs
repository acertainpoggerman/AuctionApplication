using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Data.Services
{
    public class ListingService : IListingService
    {
        private readonly ApplicationDbContext _context;

        public ListingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Listing?> GetById(int? id)
        {
            var listing = await _context.Listings
                .Include(l => l.User)
                .Include(l => l.Bids)
                .Include(l => l.Comments)
                .FirstOrDefaultAsync(l => l.Id == id);
    
            return listing;
        }

        public IQueryable<Listing> GetAll()
        {
            var applicationDbContext = _context.Listings.Include(l => l.User);
            return applicationDbContext;
        }
    }
}

