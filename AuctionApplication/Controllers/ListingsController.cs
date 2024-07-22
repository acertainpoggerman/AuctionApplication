using Microsoft.AspNetCore.Mvc;
using AuctionApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AuctionApplication.Controllers
{
    public class ListingsController : Controller
    {
        private readonly IListingService _listingService;
        private readonly IWebHostEnvironment _webhostEnvironment;

        public ListingsController(IListingService listingService, IWebHostEnvironment webHostEnvironment)
        {
            _listingService = listingService;
            _webhostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _listingService.GetAll();
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
