using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALFactory;
using IDAL;

namespace BLL
{
    public class BaseBll<T> where T :  IBaseBll
    {
        //IDAL<T> dal = DALFactory.DALFactory.GetBllObject("");
        public void TestCommonA()
        {
            ITestDal dal = DALFactory.DALFactory<T>.GetBllObject(new T()) as ITestDal ;
            dal.TestB();
            dal.TestCommonA();
            
        }
    }
}
