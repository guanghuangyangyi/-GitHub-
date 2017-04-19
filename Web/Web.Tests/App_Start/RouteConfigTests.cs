using Microsoft.VisualStudio.TestTools.UnitTesting;
using Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web;
using Moq;

namespace Web.Tests
{
    /// <summary>
    /// 测试路由
    /// </summary>
    [TestClass()]
    public class RouteConfigTests
    {
        [TestMethod()]
        public void RegisterRoutesTest()
        {
            //将routes按照默认路由代码中的格式生成相应的路由。
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            //创建一个HttpContextBase的mock类，使用MoQ框架来生成mock类
            var httpContextMock = new Mock<HttpContextBase>();
            httpContextMock.Setup(c => c.Request.AppRelativeCurrentExecutionFilePath).Returns("~/Home/Index");

            //routes中获得路由数据
            RouteData routeData = routes.GetRouteData(httpContextMock.Object);

            //断言路由中的内容
            Assert.IsNotNull(routeData, "Should have found the route");
            Assert.AreEqual("Home", routeData.Values["Controller"]);
            Assert.AreEqual("Index", routeData.Values["action"]);
            Assert.AreEqual("", routeData.Values["id"]);
        }
    }
}