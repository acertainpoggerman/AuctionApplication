using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comment comment)
        {
            await _commentService.Add(comment);
            return RedirectToAction("Details", "Listings", new { id = comment.ListingId });
        }
    }
}
