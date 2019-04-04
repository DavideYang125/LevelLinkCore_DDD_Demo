using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Model;
using LevelLinkCore.Infrastructure;

namespace LevelLinkCore.InfrastructureTest.Repositories
{
    public class ProvinceRepository : BaseRepository<Province>, IProvinceRepository
    {
        private LevelLinkContext _context;

        public ProvinceRepository(LevelLinkContext _context) : base(_context)
        {
            this._context = _context;
        }
        public int GetCityCount(Province province)
        {
            return 0;
        }

    }
}
