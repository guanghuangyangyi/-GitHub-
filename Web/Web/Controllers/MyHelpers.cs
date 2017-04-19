using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.Controllers
{
    public static class MyHelpers
    {
        public static string UnorderedList<T>(this HtmlHelper html, IEnumerable<T> items)
        {
            if (html == null)
            {
                throw new ArgumentNullException("html");
            }
            string ul = "<ul>";
            foreach (var item in items)
            {
                ul += "<li>" + html.Encode(item.ToString()) + "</li>";
            }
            return ul + "</ul>";
        }
    }
}
