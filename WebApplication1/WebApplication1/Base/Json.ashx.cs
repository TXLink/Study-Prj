using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplication1.Base
{
    /// <summary>
    /// Json 的摘要说明
    /// </summary>
    public class Json : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //解决跨域请求的问题
            context.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            List<Site> lSite = new List<Site>();
            Site list = new Base.Site();
            list.Name = "z百度";
            list.Url = "www.baidu.com";
            list.Country = "中国";
            lSite.Add(list);
            list = new Base.Site();
            list.Name = "a谷歌";
            list.Url = "www.google.com";
            list.Country = "美国";
            lSite.Add(list);
            list = new Base.Site();
            list.Name = "b雅虎";
            list.Url = "www.yahoo.com";
            list.Country = "美国";
            lSite.Add(list);

            var js = new JavaScriptSerializer().Serialize(lSite);

            context.Response.Write(js);
        }




        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Site
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string Country { get; set; }

    }
}