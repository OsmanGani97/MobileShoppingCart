using System.Diagnostics;
using DMobileSite.Models;
using DMobileSite.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DMobileSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeRepository _homeRepository;

        public HomeController(ILogger<HomeController> logger, IHomeRepository homeRepository)
        {
            _logger = logger;
            _homeRepository = homeRepository;
        }

        public async Task<IActionResult> Index(string sterm = "", int brandId = 0)
        {
            //var mobileModel = new MobileDisplayModel();

            IEnumerable<Mobile> mobiles = await _homeRepository.GetMobiles(sterm, brandId);
            IEnumerable<Brand> brands = await _homeRepository.Brands();
            MobileDisplayModel mobileModel = new MobileDisplayModel
            //First use this (var mobileModel = new MobileDisplayModel();)
            //then MobileDisplayModel mobileModel = new MobileDisplayModel Ta na hole 2nd ta kaj korbe na
            

            {
                Mobiles = mobiles,
                Brands = brands,
                STerm = sterm,
                BrandId= brandId
                
                
            };
            return View(mobileModel);
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
