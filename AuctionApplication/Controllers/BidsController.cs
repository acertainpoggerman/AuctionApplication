using AuctionApplication.Data.Interfaces;
using AuctionApplication.Data.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApplication.Controllers
{
    public class BidsController : Controller
    {
        private readonly IBidService _bidService;
        public BidsController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Bid bid)
        {
            await _bidService.Add(bid);
            return RedirectToAction("Details", "Listings", new { id = bid.ListingId });
        }
    }
}
