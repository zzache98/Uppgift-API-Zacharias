using Microsoft.EntityFrameworkCore;

namespace Inlämning_API.Models
{
    public class AdsContext : DbContext
    {

        public AdsContext(DbContextOptions<AdsContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Ads> Adverts { get; set; }
    }


}
