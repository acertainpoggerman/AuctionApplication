using AuctionApplication.Models;

namespace AuctionApplication.Data.Interfaces
{
    public interface IBidService
    {
        IQueryable<Bid> GetAll();
        Task<List<Bid>?> GetAllForListing(int? id, int count = 10);

        Task Add(Bid bid);
    }
}
