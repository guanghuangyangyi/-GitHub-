//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace 反射
//{
//    public class Tool
//    {
//        public void WriteReflectionInfo()
//        {
//            Type testType = typeof(Test);
//            Assembly assembly = testType.Assembly;
//            Response.Write("Assembly：" + assembly.FullName + "<br/>");
//            Type[] typeList = assembly.GetTypes();   // 获取类型
//                                                     // 针对每个类型获取详细信息
//            foreach (Type type in typeList)
//            {
//                Response.Write("------------------------" + type.Namespace + type.Name + "------------------------<br/>");
//                // 获得类型的结构信息
//                ConstructorInfo[] constructs = type.GetConstructors();

//                // 获得类型的字段信息
//                FieldInfo[] fields = type.GetFields();
//                Response.Write("<b>类的公共字段信息如下：</b>" + "<br/>");
//                int a1 = 1;
//                foreach (FieldInfo field in fields)
//                {
//                    Response.Write((a1++).ToString() + ". " + field.Name + "<br/>");
//                }

//                // 获得方法信息
//                MethodInfo[] methods = type.GetMethods();

//                Response.Write("<b>类的公共方法如下：</b>" + "<br/>");
//                int a2 = 1;
//                foreach (MethodInfo method in methods)
//                {
//                    ParameterInfo[] parameters = method.GetParameters();
//                    ParameterInfo reparam = method.ReturnParameter;
//                    Response.Write((a2++).ToString() + ". " + reparam.ParameterType.Name + " " + method.Name + "(");
//                    int index = 0;
//                    foreach (ParameterInfo para in parameters)
//                    {
//                        if (index++ < parameters.Length - 1)
//                            Response.Write(para.ParameterType.Name + " " + para.Name + ",");
//                        else
//                            Response.Write(para.ParameterType.Name + " " + para.Name);
//                    }
//                    Response.Write(")<br/>");
//                }

//                // 获得属性的信息
//                PropertyInfo[] propertys = type.GetProperties();

//                Response.Write("<b>类的公共属性如下：</b>" + "<br/>");
//                int a3 = 1;
//                foreach (PropertyInfo pro in propertys)
//                {
//                    Response.Write((a3++).ToString() + ". " + pro.PropertyType.Name + " " + pro.Name + "{");
//                    if (pro.CanRead) Response.Write("get;");
//                    if (pro.CanWrite) Response.Write("set;");
//                    Response.Write("}<br/>");
//                }
//                // 获得事件信息
//                EventInfo[] events = type.GetEvents();

//                Response.Write("<b>类的成员如下：</b>" + "<br/>");
//                // 获得成员
//                int a4 = 1;
//                foreach (MemberInfo mi in type.GetMembers())
//                {
//                    Response.Write((a4++).ToString() + ". " + mi.MemberType.ToString() + " : " + mi.Name + "<br/>");
//                }
//            }
//    }


//        private void Assembly_CreateInstance()
//        {
//            string assemblyName = "SqlModel";
//            string className = assemblyName + ".Member";
//            // 创建无参数实例
//            IDAL.IMember member = (IDAL.IMember)Assembly.Load(assemblyName).CreateInstance(className);
//            Response.Write("创建无参数实例：" + member.ID + "<br/>");
//            // 创建有参数实例
//            Object[] parameters = new Object[1];
//            parameters[0] = 10000;
//            IDAL.IMember member1 = (IDAL.IMember)Assembly.Load(assemblyName).CreateInstance(className, false, BindingFlags.Default, null, parameters, null, null);
//            Response.Write("创建有参数实例：" + member1.ID + "<br/>");
//        }

//        // 使用Activator的CreateInstance方法来取得对象的实例
//        private void Activator_CreateInstance()
//        {
//            string assemblyName = "SqlModel";
//            string className = assemblyName + ".Member";
//            // 创建无参数实例
//            System.Runtime.Remoting.ObjectHandle obj = Activator.CreateInstance(assemblyName, className);
//            IDAL.IMember member = (IDAL.IMember)obj.Unwrap();
//            Response.Write("创建无参数实例：" + member.ID + "<br/>");
//            // 创建有参数实例
//            Object[] parameters = new Object[1];
//            parameters[0] = 10000;
//            System.Runtime.Remoting.ObjectHandle obj1 = Activator.CreateInstance(assemblyName, className, false, BindingFlags.CreateInstance, null, parameters, null, null, null);
//            IDAL.IMember member1 = (IDAL.IMember)obj1.Unwrap();
//            Response.Write("创建有参数实例：" + member1.ID + "<br/>");
//        }

//        // 使用Type的InvokeMember方法来取得对象的实例
//        private void Type_InvokeMember()
//        {
//            string assemblyName = "SqlModel";
//            string className = assemblyName + ".Member";
//            Assembly assem = Assembly.Load(assemblyName);
//            Type type = assem.GetType(className);   // 註意这里如果使用Type.GetType来取得Type的话，那麼assemblyName指定的类一定要是强命名的
//                                                    // 创建无参数实例
//            IDAL.IMember member = (IDAL.IMember)type.InvokeMember(className, BindingFlags.CreateInstance, null, null, null);
//            Response.Write("创建无参数实例：" + member.ID + "<br/>");
//            // 创建有参数实例
//            Object[] parameters = new Object[1];
//            parameters[0] = 10000;
//            IDAL.IMember member1 = (IDAL.IMember)type.InvokeMember(className, BindingFlags.CreateInstance, null, null, parameters);
//            Response.Write("创建有参数实例：" + member1.ID + "<br/>");
//        }
//        // Type对象的 InvokeMember方法来动态调用方法
//        private void InvokeMember()
//        {
//            string assemblyName = "SqlModel";
//            string className = assemblyName + ".Member";
//            string methodName = String.Empty;
//            string result = String.Empty;
//            Assembly assem = Assembly.Load(assemblyName);
//            Object obj = assem.CreateInstance(className);
//            Type type = assem.GetType(className);   // 註意这里如果使用Type.GetType来取得Type的话，那麼assemblyName指定的类一定要是强命名的
//                                                    // 动态调用无参数的方法
//            methodName = "GetName";
//            result = (string)type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, null);
//            Response.Write(methodName + "方法的返回值：" + result + "<br/>");
//            // 动态调用有参数的方法
//            methodName = "Update";
//            Object[] methodParams = new Object[1];
//            methodParams[0] = DateTime.Now;
//            result = (string)type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, methodParams);
//            Response.Write(methodName + "方法的返回值：" + result + "<br/>");
//            // 动态调用参数构架函数的带有参数的方法
//            Object[] parameters = new Object[1];
//            parameters[0] = 10000;
//            obj = assem.CreateInstance(className, false, BindingFlags.CreateInstance, null, parameters, null, null);
//            result = (string)type.InvokeMember(methodName, BindingFlags.InvokeMethod, null, obj, methodParams);
//            Response.Write(methodName + "方法的返回值：" + result + "<br/>");
//        }

//        // MethodInfo对象的Invoke方法来动态调用方法

//        private void MethodInfo_Invoke()
//        {
//            string assemblyName = "SqlModel";
//            string className = assemblyName + ".Member";
//            string methodName = String.Empty;
//            string result = String.Empty;

//            Assembly assem = Assembly.Load(assemblyName);
//            Object obj = assem.CreateInstance(className);
//            Type type = assem.GetType(className);   // 註意这里如果使用Type.GetType来取得Type的话，那麼assemblyName指定的类一定要是强命名的
//                                                    // 动态调用无参数的方法
//            methodName = "GetName";
//            MethodInfo methodInfo = type.GetMethod(methodName);
//            result = (string)methodInfo.Invoke(obj, null);
//            Response.Write(methodName + "方法的返回值：" + result + "<br/>");
//            // 动态调用有参数的方法
//            methodName = "Update";
//            Object[] methodParams = new Object[1];
//            methodParams[0] = DateTime.Now;
//            MethodInfo method = type.GetMethod(methodName);
//            result = (string)method.Invoke(obj, methodParams);
//            Response.Write(methodName + "方法的返回值：" + result + "<br/>");
//        }

//    }
