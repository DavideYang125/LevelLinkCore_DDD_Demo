using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LevelLinkCore.Application;
using Microsoft.AspNetCore.Mvc;

namespace LevelLinkCore.Web.Controllers
{
    public class LevelLinkController : Controller
    {
        private readonly ILevelLinkAppService _levelLinkService;
        public LevelLinkController(ILevelLinkAppService levelLinkService)
        {
            _levelLinkService = levelLinkService;
        }
        public IActionResult Index()
        {
            _levelLinkService.AddSingleProvince("河南_测试");//测试
            return View();
        }     
        public JsonResult AddProvince(string provinceName)
        {
            try
            {
                _levelLinkService.AddSingleProvince(provinceName);
                return Json(new { Data = "OK" });
            }
            catch (Exception ex)
            {
                return Json(new { Data = "FAIL" });
            }       
        }
        public JsonResult AddCity(int provinceId, string cityName)
        {
            try
            {
                _levelLinkService.AddSingleCity(provinceId, cityName);
                return Json(new { Data = "SUCCESS" });
            }
            catch(Exception ex)
            {
                return Json(new { Data = "FAIL" });
            }          
        }
    }
}