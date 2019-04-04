using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Model;
using LevelLinkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LevelLinkCore.InfrastructureTest.Repositories
{
    public class CityRepository:BaseRepository<City>,ICityRepository
    {
        private LevelLinkContext _context;
        public CityRepository(LevelLinkContext _context):base(_context)
        {
            this._context = _context;
            this.Table = _dbContext.Set<City>();
        }
        public List<City> GetByProvinceId(int provinceId)
        {
            var result = Table.AsQueryable().Where(l => l.ProvinceId == provinceId).OrderBy(l => l.Id).ToList();
            return result;
        }
    }
}
