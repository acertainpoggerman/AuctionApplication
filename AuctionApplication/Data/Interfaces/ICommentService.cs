using AuctionApplication.Models;

namespace AuctionApplication.Data.Interfaces
{
    public interface ICommentService
    {
        IQueryable<Comment> GetAll();
        Task<List<Comment>?> GetCommentsForListing(int listingId);
        //Task<List<Comment>?> GetCommentsForUser(int userId);
        Task Add(Comment comment);
    }
}
