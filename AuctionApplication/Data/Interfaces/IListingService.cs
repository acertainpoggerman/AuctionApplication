using AuctionApplication.Models;

namespace AuctionApplication.Data.Interfaces
{
    public interface IListingService
    {
        IQueryable<Listing> GetAll();
        Task<Listing?> GetById(int? id);
        Task Add(Listing listing);
    }
}
