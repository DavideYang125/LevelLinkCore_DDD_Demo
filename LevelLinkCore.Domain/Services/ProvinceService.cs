using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelLinkCore.Domain.Services
{
    public class ProvinceService : IProvinceService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProvinceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// add a province info
        /// </summary>
        /// <param name="provinceName"></param>
        public void AddSingleProvince(string provinceName)
        {
            var province = new Province { Name = provinceName };
            _unitOfWork.ProvinceRepository.Insert(province);
            _unitOfWork.SaveChange();
            var id = province.Id;
            var idStr = id.ToString();
            if (idStr.Length == 1) idStr = "0" + idStr;
            var unique = idStr + "0000";
            province.Unique = unique;
        }
    }
}
