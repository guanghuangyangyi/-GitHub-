
using System;
using System.Security.Principal;
using System.Web.Security;

namespace Web
{
    /// <summary>
    /// 通用的用户实体
    /// </summary>
    /// <typeparam name="TUserData"></typeparam>
    public class MyFormsPrincipal<TUserData> : IPrincipal where TUserData : class, new()
    {
        /// <summary>
        /// 当前用户实例,实现IPrincipal接口必须要的
        /// </summary>
        public IIdentity Identity { get; private set; }
        //用户数据
        public TUserData UserData { get; private set; }

        /// <summary>
        /// 角色验证,实现IPrincipal接口必须要的
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public bool IsInRole(string role)
        {
            var userData = UserData as MyUserDataPrincipal;
            if (userData == null)
                throw new NotImplementedException();

            return userData.IsInRole(role);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticket"></param>
        /// <param name="userData"></param>
        public MyFormsPrincipal(FormsAuthenticationTicket ticket, TUserData userData)
        {
            if (ticket == null)
                throw new ArgumentNullException("ticket");
            if (userData == null)
                throw new ArgumentNullException("userData");

            Identity = new FormsIdentity(ticket);
            UserData = userData;
        }


    }
}
