using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Model;
using System;
using System.Linq;

namespace LevelLinkCore.Domain.Services
{
    /// <summary>
    /// city相关的领域服务
    /// </summary>
    public class CityService:ICityService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 增加城市信息。
        /// </summary>
        /// <param name="provinceId"></param>
        /// <param name="cityName"></param>
        public void AddSingleCity(int provinceId, string cityName)
        {
            var province = _unitOfWork.ProvinceRepository.GetByID(provinceId);
            var proUnique = province.Unique.Substring(0, 2);
            var lastCity = _unitOfWork.CityRepository.GetByProvinceId(provinceId).Last();
            var lastUnique = lastCity.Unique;
            var nextNum = Convert.ToInt32(lastUnique.Substring(2, 2)) + 1;
            var uniqueStr = nextNum.ToString();
            if (uniqueStr.Length == 1) uniqueStr = "0" + uniqueStr;
            var cityUnique = proUnique + uniqueStr + "00";
            var city = new City() { Name = cityName, ProvinceId = provinceId };
            _unitOfWork.CityRepository.Insert(city);
            _unitOfWork.SaveChange();

            city.Unique = cityUnique;
            _unitOfWork.CityRepository.Update(city);
        }
    }
}
