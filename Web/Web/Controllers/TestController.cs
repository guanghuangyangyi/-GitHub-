// *********************************************************************************
//
// 文件名称(File Name)：         TestController.cs
// 作者(Author)：                yjq
// 日期(Create Date)：           2017.03.13
// 功能描述(Depiction)：         测试的控制器
//
// 修改记录(Revision History)：
//      R1:
//          修改作者：
//          修改日期：
//          修改原因：
//
//      R2:
//          修改作者：
//          修改日期：
//          修改原因：
//
// ***********************************************************************************
using BLL;
using BLLFactory;
using Commons;
using IBLL;
using Model;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }

        /// <summary>
        /// 在需要验证角色的action上添加[MyAuthorize]的特性就可以了
        /// </summary>
        /// <returns></returns>
        [MyAuthorize(Roles = "User", Users = "bomo,toroto")]
        public ActionResult Test()
        {
            return View();
        }

        public JsonResult A()
        {
            ResultData resultData = new ResultData();
            ITestBll testBll = new TestBll();

            return Json(resultData, JsonRequestBehavior.AllowGet);
        }

        public ActionResult aaa()
        {
            ITestBll test = BllFactory<Test>.GetBllObject(new Test()) as ITestBll;
            test.TestB();
            test.TestCommonA();
            return null;
        }
    }
}