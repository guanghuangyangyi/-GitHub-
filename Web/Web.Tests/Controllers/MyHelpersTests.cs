using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.Controllers.Tests
{
    [TestClass()]
    public class MyHelpersTests
    {
        [TestMethod()]
        public void UnorderdListTest()
        {
            //var contextMock = new Mock<HttpContextBase>();
            //            var controllerMock = new Mock<ControllerBase>();
            //            var view = new Mock<IView>();
            //            var cc = new ControllerContext(contextMock.Object, new RouteData(), controllerMock.Object);
            //            var viewContext = new ViewContext(cc, view.Object, new ViewDataDictionary(), new TempDataDictionary());
            //            var vdcMock = new Mock<IViewDataContainer>();
            //             var helper = new HtmlHelper(viewContext, vdcMock.Object);
            //             string output = helper.UnorderedList(new int[] { 0, 1, 2 });
            //             Assert.AreEqual("<ul><li>0</li><li>1</li><li>2</li></ul>", output);
        }
    }
}