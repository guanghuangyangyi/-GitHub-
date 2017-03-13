using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
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
    }
}