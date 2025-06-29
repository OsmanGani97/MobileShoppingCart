
using DMobileSite.Models;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace DMobileSite.Repository
{
    public class HomeRepository: IHomeRepository
    {
        private readonly ApplicationDbContext _db;

        public HomeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Brand>> Brands()
        {
            return await _db.Brands.ToListAsync();
        }
        public async Task<IEnumerable<Mobile>> GetMobiles(string sTerm = "", int brandId = 0)
        {
            sTerm = sTerm.ToLower();
            IEnumerable<Mobile> mobiles =await (from mobile in _db.Mobiles
                           join brand in _db.Brands
                           on mobile.BrandId equals brand.Id

                           join stock in _db.Stocks
                           on mobile.Id equals stock.MobileId
                           into mobile_stocks
                           from mobileWithStock in mobile_stocks.DefaultIfEmpty()

                           where string.IsNullOrWhiteSpace(sTerm) ||
                           (mobile != null && mobile.MobileName.ToLower().StartsWith(sTerm))
                           select new Mobile
                           {
                               
                               Id= mobile.Id,
                               MobileName=mobile.MobileName,
                               Image=mobile.Image,
                               Price=mobile.Price,
                               Stroage=mobile.Stroage,
                               Ram=mobile.Ram,
                               MainCamera=mobile.MainCamera,
                               ForntCamera=mobile.ForntCamera,
                               BrandId=mobile.BrandId,
                               Display=mobile.Display,
                               Battery=mobile.Battery,
                               OperatingSystem=mobile.OperatingSystem,
                               Quantity = mobileWithStock == null ? 0 : mobileWithStock.Quantity,

                               BrandName = brand.BrandName
                           }

                         ).ToListAsync();
            if(brandId > 0)
            {
                mobiles= mobiles.Where(a=>a.BrandId == brandId).ToList();
            }
            return mobiles;
        }
    }
}
