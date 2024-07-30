using AuctionApplication.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var bids = await _bidService.GetAll()
                .Where(b => b.ListingId == listingId)
                .OrderByDescending(b => b.Price)
                .Take(count)
                .ToListAsync();

            return View(bids);
        }
    }
}
