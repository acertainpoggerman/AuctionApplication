using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.ViewComponents
{
    public class CommentInputViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentInputViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(Listing listing)
        {
            return View(listing);
        }
    }
}
