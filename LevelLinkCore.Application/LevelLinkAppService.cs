using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Services;

namespace LevelLinkCore.Application
{
    public class LevelLinkAppService:ILevelLinkAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICityService _cityService;
        private readonly IProvinceService _provinceService;
        public LevelLinkAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _cityService = new CityService(_unitOfWork);
            _provinceService = new ProvinceService(_unitOfWork);
        }
        public void AddSingleCity(int provinceId, string cityName)
        {
            var province = _unitOfWork.ProvinceRepository.GetByID(provinceId);
            
            _cityService.AddSingleCity(provinceId, cityName);
            province.CityCount = province.CityCount + 1;
            _unitOfWork.SaveChange();
        }

        public void AddSingleProvince(string provinceName)
        {
            _provinceService.AddSingleProvince(provinceName);
            _unitOfWork.SaveChange();
        }

        public void AddSingleRegion(int cityId, string regionName)
        {
            throw new System.NotImplementedException();
        }
    }
}
