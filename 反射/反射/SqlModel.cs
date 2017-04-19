//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SqlModel
//{
//    public class Member : IDAL.IMember
//    {
//        private int _id = 100;
//        public int ID
//        {
//            get { return _id; }
//            set { _id = value; }
//        }
//        private string _name = "limin";
//        public string Name
//        {
//            get { return _name; }
//            set { _name = value; }
//        }

//        public Member() { }
//        public Member(int id)
//        {
//            _id = id;
//        }

//        private void Init()
//        { }

//        public string GetName()
//        {
//            return _name;
//        }
//        public string Update(DateTime cdate)
//        {
//            return "{" + String.Format("ID:{0},Name:{1},CreateDate:{2}", _id, _name, cdate) + "}";
//        }
//    }
//}
