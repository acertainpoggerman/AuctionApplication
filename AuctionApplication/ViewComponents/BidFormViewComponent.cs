using AuctionApplication.Data.Interfaces;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.ViewComponents
{
    public class BidFormViewComponent : ViewComponent
    {
        private readonly IBidService _bidService;
        public BidFormViewComponent(IBidService bidService)
        {
            _bidService = bidService;
        }

        public IViewComponentResult Invoke(Listing listing)
        {
            return View(listing);
        }
    }
}
