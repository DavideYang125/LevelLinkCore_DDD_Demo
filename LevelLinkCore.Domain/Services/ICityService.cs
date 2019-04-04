using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.Services
{
    public interface ICityService
    {
        void AddSingleCity(int provinceId, string cityName);
    }
}
