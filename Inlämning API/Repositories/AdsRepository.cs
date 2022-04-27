using Inlämning_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Inlämning_API.Repositories
{
    public class AdsRepository : IAdsRepository
    {
        private readonly AdsContext _context;

        public AdsRepository(AdsContext context)
        {
            _context = context;
        }
        public async Task<Ads> Create(Ads ads)
        {
            _context.Adverts.Add(ads);
            await _context.SaveChangesAsync();

            return ads;
        }

        public async Task Delete(int id)
        {
            var adsToDelete = await _context.Adverts.FindAsync(id);
            _context.Adverts.Remove(adsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ads>> Get()
        {
            return await _context.Adverts.ToListAsync();
        }

        public async Task<Ads> Get(int id)
        {
            return await _context.Adverts.FindAsync(id);
        }

        public async Task Update(Ads ads)
        {
            _context.Entry(ads).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
