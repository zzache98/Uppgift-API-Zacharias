using Inlämning_API.Models;

namespace Inlämning_API.Repositories
{
    public interface IAdsRepository
    {
        Task<IEnumerable<Ads>> Get();

        Task<Ads> Get(int id);

        Task<Ads> Create(Ads ads);

        Task Update(Ads ads);

        
        Task Delete(int id);
        
    }
}
