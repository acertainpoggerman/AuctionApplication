using AuctionApplication.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.ViewComponents
{
    public class CommentSectionViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentSectionViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listingId)
        {
            var listings = await _commentService.GetCommentsForListing(listingId);
            return View(listings);
        } 
    }
}
