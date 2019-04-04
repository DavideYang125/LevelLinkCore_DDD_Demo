using LevelLinkCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.IRepositories
{
    public interface IProvinceRepository: IRepository<Province>
    {
        int GetCityCount(Province province);
    }
}
