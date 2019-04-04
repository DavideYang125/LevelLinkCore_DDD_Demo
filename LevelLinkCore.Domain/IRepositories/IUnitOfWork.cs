using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.IRepositories
{
    /// <summary>
    /// 工作单元模式
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        ICityRepository CityRepository { get; }
        IProvinceRepository ProvinceRepository { get; }
        void SaveChange();
    }
}
