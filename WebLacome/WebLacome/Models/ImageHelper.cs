using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebLacome.Models
{
    public static class ImageHelper
    {
        public static MvcHtmlString ANH(this HtmlHelper helper, string src, string altText, string height)
        {
            var builder = new TagBuilder("ANH");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}