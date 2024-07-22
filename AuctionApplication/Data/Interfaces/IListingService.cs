using AuctionApplication.Models;

namespace AuctionApplication.Data.Interfaces
{
    public interface IListingService
    {
        IQueryable<Listing> GetAll();
    }
}
