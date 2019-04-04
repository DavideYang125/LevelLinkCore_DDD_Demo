using LevelLinkCore.Application;
using LevelLinkCore.Domain.IRepositories;
using LevelLinkCore.InfrastructureTest;
using System;

namespace LevelLinkCore.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {

            TestAdd testAdd = new TestAdd();
            testAdd.AddTestC(1, "新郑");
             //testAdd.AddTestC(1, "开封");
              //testAdd.AddTestC(1, "洛阳");
            //testAdd.AddTestC(2, "西安");
            //testAdd.AddTestC(2, "延安");
            //testAdd.AddTestC(2, "咸阳");
            //testAdd.AddTestP("河南");
            //testAdd.AddTestP("西安");
            //testAdd.AddTest();
            Console.WriteLine("添加完成");
            Console.WriteLine("Hello World!");
        }
    }
    public class TestAdd
    {
        private static IUnitOfWork unitOfWork = new UnitOfWork();
        private ILevelLinkAppService _customerAppService = new LevelLinkAppService(unitOfWork);

        //public TestAdd()
        //{
        //    _customerAppService = customerAppService;
        //}
        public void AddTestP(string name)
        {
            _customerAppService.AddSingleProvince(name);
            //_customerAppService.AddSingleCity("郑州");
        }
        public void AddTestC(int pid, string name)
        {
            //_customerAppService.AddSingleProvince(name);
            _customerAppService.AddSingleCity(pid, name);
        }
    }
}
