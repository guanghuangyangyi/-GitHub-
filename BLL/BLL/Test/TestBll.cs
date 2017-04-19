using IBLL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TestBll : BaseBll<Test>, ITestBll
    {
        public void TestB()
        {
            ITestDal dal = DALFactory.DALFactory<Test>.GetBllObject(new Test()) as ITestDal;
            dal.TestB();
        }
    }
}
