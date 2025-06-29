using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMobileSite.Controllers
{
    [Authorize(Roles = nameof(Roles.Admin))]
    public class MobileDetailsController(ApplicationDbContext db, IWebHostEnvironment env) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var data = await db.Mobiles.Include(x => x.General).ToListAsync();
            data = await db.Mobiles.Include(x => x.Displays).ToListAsync();
            data = await db.Mobiles.Include(x => x.Camera).ToListAsync();
            data = await db.Mobiles.Include(x => x.Designs).ToListAsync();
            data = await db.Mobiles.Include(x => x.Batterys).ToListAsync();
            data = await db.Mobiles.Include(x => x.Memory).ToListAsync();
            data = await db.Mobiles.Include(x => x.Network_Connectivity).ToListAsync();
            data = await db.Mobiles.Include(x => x.Sensors_security).ToListAsync();
            data = await db.Mobiles.Include(x => x.Multimedia).ToListAsync();
            data = await db.Mobiles.Include(x => x.More).ToListAsync();

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
