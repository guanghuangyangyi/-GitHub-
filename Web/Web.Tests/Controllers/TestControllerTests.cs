// *********************************************************************************
//
// 文件名称(File Name)：         TestControllerTests.cs
// 作者(Author)：                yjq
// 日期(Create Date)：           2017.03.13
// 功能描述(Depiction)：         测试Test控制器
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
/// <summary>
/// 1.测试路由
/// 2.测试controller的action
///     1.测试viewdata
///     2.redirect to action
/// 3.测试helper(涉及到逻辑的view代码写到helper中)
/// </summary>
namespace Web.Controllers.Tests
{
    /// <summary>
    /// 测试controller
    /// </summary>
    [TestClass()]
    public class TestControllerTests
    {
        /// <summary>
        /// 测试控制器的方法  viewData的测试
        /// </summary>
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange 对象
            TestController controller = new TestController();

            // Act  行为动作
            ViewResult result = controller.Index() as ViewResult;

            // Assert 断言
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
        }

        [TestMethod()]
        public void TestTest()
        {
            // Arrange 对象
            TestController controller = new TestController();

            // Act  行为动作
            ViewResult result = controller.Test() as ViewResult;

            // Assert 断言
            ViewDataDictionary viewData = result.ViewData;
            Assert.AreEqual("aa", viewData);
        }
    }
}