using Microsoft.VisualStudio.TestTools.UnitTesting;
using DALFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDAL;
using DAL;
using Model;

namespace DALFactory.Tests
{
    [TestClass()]
    public class DALFactoryTests
    {
        [TestMethod()]
        public void GetDalObjectTest()
        {
            // Arrange 对象


            // Act  行为动作
            //ITestDal test = DALFactory<Test>.GetBllObject(new Test()) as TestEFDal;

            // Assert 断言
            //ViewDataDictionary viewData = result.ViewData;
            //Assert.AreEqual("Welcome to ASP.NET MVC!", viewData["Message"]);
            //Assert.IsNotNull(test);
        }
    }
}