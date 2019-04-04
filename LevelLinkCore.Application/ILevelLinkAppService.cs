using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Application
{
    public interface ILevelLinkAppService
    {
        void AddSingleCity(int provinceId, string cityName);
        void AddSingleProvince(string provinceName);
        void AddSingleRegion(int cityId, string regionName);
    }
}
