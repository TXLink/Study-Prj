using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace WebApplication1.ChangeEvent
{
    /// <summary>
    /// json 的摘要说明
    /// </summary>
    public class json : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //解决跨域请求的问题
            //context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
            List<Site> list = new List<Site>();
            if (context.Request.QueryString["id"] != null)
            {
                string id = context.Request.QueryString["id"].ToString();
                if (id.Contains("1"))
                {
                    list = GetSite01();
                }
                else
                {
                    list = GetSite02();
                }
            }

            context.Response.Write(new JavaScriptSerializer().Serialize(list));
        }


        public List<Site> GetSite01()
        {
            List<Site> lSite = new List<Site>();
            Site list = new Site();
            list.Name = "z百度";
            list.Url = "www.baidu.com";
            list.Country = "中国";
            lSite.Add(list);
            list = new Site();
            list.Name = "a谷歌";
            list.Url = "www.google.com";
            list.Country = "美国";
            lSite.Add(list);
            list = new Site();
            list.Name = "b雅虎";
            list.Url = "www.yahoo.com";
            list.Country = "美国";
            lSite.Add(list);
            return lSite;
        }

        public List<Site> GetSite02()
        {
            List<Site> lSite = new List<Site>();
            Site list = new Site();
            list.Name = "baidu";
            list.Url = "www.baidu.com";
            list.Country = "china";
            lSite.Add(list);
            list = new Site();
            list.Name = "google";
            list.Url = "www.google.com";
            list.Country = "american";
            lSite.Add(list);
            list = new Site();
            list.Name = "yahoo";
            list.Url = "www.yahoo.com";
            list.Country = "american";
            lSite.Add(list);
            return lSite;
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