using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Data.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        public CommentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Comment>?> GetCommentsForListing(int listingId)
        {
            var comments = await _context.Comments
                .Where(b => b.ListingId == listingId)
                .Include(b => b.User)
                .OrderByDescending(b => b.Id)
                .ToListAsync();

            return comments;
        }

        public async Task Add(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}
