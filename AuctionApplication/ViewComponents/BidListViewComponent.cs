using AuctionApplication.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.ViewComponents
{
    public class BidListViewComponent : ViewComponent
    {
        private readonly IBidService _bidService;
        public BidListViewComponent(IBidService bidService)
        {
            _bidService = bidService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int listingId, int count = 10)
        {
            var bids = await _bidService.GetBidsForListing(listingId);
            return View(bids);
        }
    }
}
