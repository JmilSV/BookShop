using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webNew3.CustomHtmlHelpers
{
    public static class CustomHtmlHelpers
    {
        /// <summary>
        /// генерує тег 'img' з відповідними атрибутами
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="src">вкажіть відносний шлях</param>
        /// <param name="alt"></param>
        /// <returns></returns>
        public static IHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            TagBuilder tb = new TagBuilder("img");
            tb.Attributes.Add("src", VirtualPathUtility.ToAbsolute(src));
            tb.Attributes.Add("alt", alt);

            return new MvcHtmlString(tb.ToString(TagRenderMode.SelfClosing));
        }
        public static string GetAbsolute(this HtmlHelper helper, string src)
        {
            return(VirtualPathUtility.ToAbsolute(src));
        }
    }
}