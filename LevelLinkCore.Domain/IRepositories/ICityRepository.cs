using LevelLinkCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.IRepositories
{
    public interface ICityRepository: IRepository<City>
    {
        List<City> GetByProvinceId(int provinceId);
    }
}
