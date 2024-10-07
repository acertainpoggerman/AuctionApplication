using AuctionApplication.Models;

namespace AuctionApplication.Data.Interfaces
{
    public interface IBidService
    {
        IQueryable<Bid> GetAll();
        Task<List<Bid>?> GetBidsForListing(int listingId, int count = 10);
        Task Add(Bid bid);
    }
}
