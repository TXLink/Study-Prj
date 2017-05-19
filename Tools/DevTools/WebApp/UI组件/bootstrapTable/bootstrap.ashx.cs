using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace XuyinglinTools.UI.bootstrapTable
{
    /// <summary>
    /// bootstrap 的摘要说明
    /// </summary>
    public class bootstrap : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string cmd = context.Request["cmd"].ToString();
            int page =int.Parse( context.Request["page"]);
            int rows = int.Parse(context.Request["rows"]);
            switch (cmd)
            {
                case "loadData":
                    BootStrapTableData(page,rows);
                    break;
            }
        }


        /// <summary>
        /// 模拟数据
        /// </summary>
        /// <returns></returns>
        public void BootStrapTableData(int page,int rows)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();

            var lstRes = new List<Dept>();
            for (var i = 0; i < 50; i++)
            {
                var oModel = new Dept();
                oModel.Id = Guid.NewGuid().ToString();
                oModel.Name = "开发部" + i;
                oModel.ProductName = "产品"+i.ToString();
                oModel.CompanyName = "Microsoft";
                oModel.CreateBy = "yinglinxu";
                oModel.CreateTime = DateTime.Now;
                lstRes.Add(oModel);
            }

            var total = lstRes.Count;
            var getRows = lstRes.Skip(page).Take(rows).ToList();
            string returnJS = js.Serialize(new { total = total, rows = getRows });
            HttpContext.Current.Response.Write(returnJS);
        }


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    public class Dept
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ProductName { get; set; }

        public string CompanyName { get; set; }

        public string CreateBy { get; set; }

        public DateTime CreateTime { get; set; }
    }

}