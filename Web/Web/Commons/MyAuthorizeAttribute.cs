// *********************************************************************************
//
// 文件名称(File Name)：         MyAuthorizeAttribute.cs
// 作者(Author)：                yjq
// 日期(Create Date)：           2017.03.13
// 功能描述(Depiction)：         测试mvc的验证
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web
{
    /// <summary>
    /// 用于验证角色和用户名的Authorize特性
    /// </summary>
    public class MyAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var user = httpContext.User as MyFormsPrincipal<MyUserDataPrincipal>;
            if (user != null)
                return (user.IsInRole(Roles) || user.IsInUser(Users));

            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //验证不通过,直接跳转到相应页面，注意：如果不使用以下跳转，则会继续执行Action方法
            filterContext.Result = new RedirectResult("http://www.baidu.com");
        }
    }
}
