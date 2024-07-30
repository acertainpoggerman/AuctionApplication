using Microsoft.AspNetCore.Mvc;
using AuctionApplication.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using AuctionApplication.Models;

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

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var listing = await _listingService.GetById(id);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ListingViewModel listing)
        {
            if (listing.Image != null)
            {
                string uploadDir = Path.Combine(_webhostEnvironment.WebRootPath, "images");
                string fileName = listing.Image.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    listing.Image.CopyTo(fileStream);
                }

                var listingObj = new Listing
                {
                    Title = listing.Title,
                    Description = listing.Description,
                    Price = listing.Price,
                    IdentityUserId = listing.IdentityUserId,
                    IsSold = false,
                    ImagePath = fileName,
                };

                await _listingService.Add(listingObj);
                return RedirectToAction("Index");
            }
            return View(listing);
        }
    }
}
