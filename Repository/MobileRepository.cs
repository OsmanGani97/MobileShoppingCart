using Microsoft.EntityFrameworkCore;

namespace DMobileSite.Repository
{
    public interface IMobileRepository
    {
        Task AddMobile(Mobile mobile);
        Task UpdateMobile(Mobile mobile);
        Task DeleteMobile(Mobile mobile);
        Task<Mobile?> GetMobileById(int id);
        Task<IEnumerable<Mobile>> GetMobiles();
    }

    public class MobileRepository : IMobileRepository
    {
        private readonly ApplicationDbContext _context;

        public MobileRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddMobile(Mobile mobile)
        {
            _context.Mobiles.Add(mobile);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMobile(Mobile mobile)
        {
            _context.Mobiles.Update(mobile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMobile(Mobile mobile)
        {
            _context.Mobiles.Remove(mobile);
            await _context.SaveChangesAsync();
        }

        public async Task<Mobile?> GetMobileById(int id) => await _context.Mobiles.FindAsync(id);

        public async Task<IEnumerable<Mobile>> GetMobiles() => await _context.Mobiles.Include(a => a.Brands).ToListAsync();
    }
}
