using log4net;
using log4net.Config;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Working.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestUIGRID()
        {
            return View();
        }



        #region TEST DOWNLOAD EXECL

        /// <summary>  
        ///测试下载下载Execl  By List<T>
        /// </summary>  
        /// <returns></returns>  
        public FileResult DownLoadExcel()
        {
            List<TestModel> list = null;
            if (TempData["LoadData"] != null)
            {
                list = TempData["LoadData"] as List<TestModel>;
            }
            else
            {
                list = TestData();
            }
            string strFileName = DateTime.Now.ToString("yyyyMMddhhmmss");//获取当前时间  

            //InitLog4Net();

            //指定方法
            //var logger = LogManager.GetLogger(typeof(HomeController));
            var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            logger.Info("     警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg：");
            logger.Warn("     警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg");
            logger.Error("    异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg异常E警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息MsgMsg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg");
            logger.Fatal("    警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg息Msg消息Msg消息Msg警告W消息Msg消息Msg消息Msg消息Msg消息Msg消息Msg");

            return (ExportExecl(list, strFileName));

        }

        /// <summary>  
        ///测试下载下载Execl  By DataTable
        /// </summary>  
        /// <returns></returns>  
        public FileResult DownLoadExcelByDataTable()
        {
            DataTable dt = CnDataTable();
            string strFileName = DateTime.Now.ToString("yyyyMMddhhmmss");//获取当前时间  
            return (ExportExecl(dt, strFileName));

        }

        /// <summary>  
        ///测试下载下载Execl  By Dictionnary
        /// </summary>  
        /// <returns></returns>  
        public FileResult DownLoadExcelByDic()
        {
            DataTable dt = DicDataTable();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("ID", "编号编号");
            dic.Add("Name", "姓名o");
            dic.Add("SerialNumber", "序列号i");
            dic.Add("Text", "文本");
            string strFileName = DateTime.Now.ToString("yyyyMMddhhmmss");//获取当前时间  
            return (ExportExecl(dt, dic, strFileName));

        }


        #endregion

        #region TEST DATA

        /// <summary>
        /// 返回测试的数据 List<TestModel>
        /// </summary>
        /// <returns></returns>
        public List<TestModel> TestData()
        {
            List<TestModel> lstTest = new List<TestModel>();
            TestModel tstModel;

            for (int i = 0; i < 20; i++)
            {
                tstModel = new TestModel();
                tstModel.ID = i + 1;
                tstModel.Name = "测试姓名";
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                tstModel.SerialNumber = num01.ToString() + num02.ToString() + num03.ToString();
                tstModel.Text = "这是一些测试的文字，没有实际意义" + i.ToString();

           
                lstTest.Add(tstModel);
            }

            return lstTest;
        }


        /// <summary>
        /// 测试返回数据Json
        /// </summary>
        /// <returns></returns>
        public JsonResult TestReturnData()
        {
            List<TestModel> lstTest = new List<TestModel>();
            TestModel tstModel;

            for (int i = 0; i < 20; i++)
            {
                tstModel = new TestModel();
                tstModel.ID = i + 1;
                tstModel.Name = "测试姓名";
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                tstModel.SerialNumber = num01.ToString() + num02.ToString() + num03.ToString();
                tstModel.Text = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text1 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text2 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text3 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text4 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text5 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text6 = "这是一些测试的文字，没有实际意义" + i.ToString();

                tstModel.Text11 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text22 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text33 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text44 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text55 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text66 = "这是一些测试的文字，没有实际意义" + i.ToString();

                tstModel.Text111 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text222 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text333 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text444 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text555 = "这是一些测试的文字，没有实际意义" + i.ToString();
                tstModel.Text666 = "这是一些测试的文字，没有实际意义" + i.ToString();

                lstTest.Add(tstModel);
            }
            //缓存数据，避免下载数据的时候重新读取数据库
            TempData["LoadData"] = lstTest;
            return Json(lstTest, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 测试返回数据Json
        /// </summary>
        /// <returns></returns>
        public JsonResult TestReturnDataAsc()
        {
            List<TestModel> lstTest = new List<TestModel>();
            TestModel tstModel;

            for (int i = 0; i < 20; i++)
            {
                tstModel = new TestModel();
                tstModel.ID = i + 1;
                tstModel.Name = "测试姓名";
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                tstModel.SerialNumber = num01.ToString() + num02.ToString() + num03.ToString();
                tstModel.Text = "这是一些测试的文字，没有实际意义" + i.ToString();
                lstTest.Add(tstModel);
            }
            //缓存数据，避免下载数据的时候重新读取数据库
            TempData["LoadData"] = lstTest;
            lstTest.Sort((x, y) => x.ID.CompareTo(y.ID));
            return Json(lstTest, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 测试返回数据Json
        /// </summary>
        /// <returns></returns>
        public JsonResult TestReturnDataDesc()
        {
            List<TestModel> lstTest = new List<TestModel>();
            TestModel tstModel;

            for (int i = 0; i < 20; i++)
            {
                tstModel = new TestModel();
                tstModel.ID = i + 1;
                tstModel.Name = "测试姓名";
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                tstModel.SerialNumber = num01.ToString() + num02.ToString() + num03.ToString();
                tstModel.Text = "这是一些测试的文字，没有实际意义" + i.ToString();
                lstTest.Add(tstModel);
            }
            //缓存数据，避免下载数据的时候重新读取数据库
            TempData["LoadData"] = lstTest;
            lstTest.Sort((x, y) => y.ID.CompareTo(x.ID));
            return Json(lstTest, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 返回中文表名
        /// </summary>
        /// <returns></returns>
        public DataTable CnDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("编号", typeof(int));
            dt.Columns.Add("姓名", typeof(string));
            dt.Columns.Add("序列号", typeof(string));
            dt.Columns.Add("文本", typeof(string));

            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr["编号"] = i + 1;
                dr["姓名"] = "测试姓名" + i.ToString();
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                dr["序列号"] = num01.ToString() + num02.ToString() + num03.ToString();
                dr["文本"] = "这是一些测试的文字，没有实际意义" + i.ToString();
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 返回中文表名
        /// </summary>
        /// <returns></returns>
        public DataTable DicDataTable()
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("SerialNumber", typeof(string));
            dt.Columns.Add("Text", typeof(string));

            for (int i = 0; i < 20; i++)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = i + 1;
                dr["Name"] = "测试姓名" + i.ToString();
                Random rd = new Random();
                int num01 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num02 = rd.Next(100000000, 999999999);
                rd = new Random();
                int num03 = rd.Next(100000000, 999999999);
                dr["SerialNumber"] = num01.ToString() + num02.ToString() + num03.ToString();
                dr["Text"] = "这是一些测试的文字，没有实际意义" + i.ToString();
                dt.Rows.Add(dr);
            }

            return dt;
        }


        #endregion

        #region TOOLS

        /// <summary>
        /// 将集合类转换成DataTable
        /// </summary>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public DataTable ToDataTable(IList list)
        {
            DataTable result = new DataTable();
            if (list.Count > 0)
            {
                PropertyInfo[] propertys = list[0].GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    result.Columns.Add(pi.Name, pi.PropertyType);
                }

                for (int i = 0; i < list.Count; i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(list[i], null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    result.LoadDataRow(array, true);
                }
            }
            return result;
        }

        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <param name="list">泛类型集合</param>
        /// <returns></returns>
        public DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的Structure
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                object[] objAttrs = entityProperties[i].GetCustomAttributes(typeof(DisplayAttribute), true);
                if (objAttrs.Length > 0)
                {
                    DisplayAttribute disAttr = objAttrs[0] as DisplayAttribute;
                    if (disAttr != null)
                    {
                        if (disAttr.Description != "0")
                        {
                            //如果发现名称相同，则加入序号，组成一个新的名称
                            if (dt.Columns.Contains(disAttr.Name))
                            {
                                dt.Columns.Add(disAttr.Name + i.ToString());
                            }
                            else
                            {
                                dt.Columns.Add(disAttr.Name);
                            }
                        }

                    }
                }
            }

            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                //object[] entityValues = new object[dt.Columns.Count];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    object[] objAttrs = entityProperties[i].GetCustomAttributes(typeof(DisplayAttribute), true);
                    if (objAttrs.Length > 0)
                    {
                        DisplayAttribute disAttr = objAttrs[0] as DisplayAttribute;
                        if (disAttr != null)
                        {
                            if (disAttr.Description != "0")
                            {
                                entityValues[i] = entityProperties[i].GetValue(entity, null);
                            }
                        }
                    }

                }
                //收缩数组 保持和数据列一致
                entityValues = entityValues.Where(p => p != null && !string.IsNullOrEmpty(p.ToString())).ToArray();
                dt.Rows.Add(entityValues);
            }
            return dt;
        }


        /// <summary>
        /// 下载Execl方法 By DataTable
        /// </summary>
        /// <param name="dt">要下载的DataTable</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public FileResult ExportExecl(DataTable dt, string fileName)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                ICellStyle HeadercellStyle = workbook.CreateCellStyle();
                HeadercellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //字体
                NPOI.SS.UserModel.IFont headerfont = workbook.CreateFont();
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                HeadercellStyle.SetFont(headerfont);


                //用column name 作为列名
                int icolIndex = 0;
                IRow headerRow = sheet.CreateRow(0);
                foreach (DataColumn item in dt.Columns)
                {
                    ICell cell = headerRow.CreateCell(icolIndex);
                    cell.SetCellValue(item.ColumnName);
                    cell.CellStyle = HeadercellStyle;
                    icolIndex++;
                }

                ICellStyle cellStyle = workbook.CreateCellStyle();

                //为避免日期格式被Excel自动替换，所以设定 format 为 『@』 表示一率当成text
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;


                NPOI.SS.UserModel.IFont cellfont = workbook.CreateFont();
                cellfont.Boldweight = (short)FontBoldWeight.Normal;
                cellStyle.SetFont(cellfont);

                //建立内容行
                int iRowIndex = 1;
                int iCellIndex = 0;
                foreach (DataRow Rowitem in dt.Rows)
                {
                    IRow DataRow = sheet.CreateRow(iRowIndex);
                    foreach (DataColumn Colitem in dt.Columns)
                    {

                        ICell cell = DataRow.CreateCell(iCellIndex);
                        cell.SetCellValue(Rowitem[Colitem].ToString());
                        cell.CellStyle = cellStyle;
                        iCellIndex++;
                    }
                    iCellIndex = 0;
                    iRowIndex++;
                }

                //自适应列宽度
                for (int i = 0; i < icolIndex; i++)
                {
                    sheet.AutoSizeColumn(i);
                }


                // 写入到客户端   
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                workbook.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms, "application/vnd.ms-excel", fileName + ".xls");

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 下载Execl方法 By DataTable
        /// </summary>
        /// <param name="dt">要下载的DataTable</param>
        /// <param name="fileName">文件名</param>
        /// <param name="columnAndValue">列名称的中文对应值</param>
        /// <returns></returns>
        public FileResult ExportExecl(DataTable dt, Dictionary<string, string> columnAndValue, string fileName)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                ICellStyle HeadercellStyle = workbook.CreateCellStyle();
                HeadercellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //字体
                NPOI.SS.UserModel.IFont headerfont = workbook.CreateFont();
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                HeadercellStyle.SetFont(headerfont);


                //用column name 作为列名
                int icolIndex = 0;
                IRow headerRow = sheet.CreateRow(0);
                foreach (DataColumn item in dt.Columns)
                {
                    ICell cell = headerRow.CreateCell(icolIndex);
                    //判断字段里面是否有导出列名对应的值了
                    var queryColumnName = columnAndValue.Where(p => p.Key.ToUpper() == item.ColumnName.ToUpper()).FirstOrDefault();
                    if (queryColumnName.Key != null)
                    {
                        cell.SetCellValue(queryColumnName.Value);
                    }
                    else
                    {
                        cell.SetCellValue(item.ColumnName);
                    }
                    cell.CellStyle = HeadercellStyle;
                    icolIndex++;
                }

                ICellStyle cellStyle = workbook.CreateCellStyle();

                //为避免日期格式被Excel自动替换，所以设定 format 为 『@』 表示一率当成text
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;


                NPOI.SS.UserModel.IFont cellfont = workbook.CreateFont();
                cellfont.Boldweight = (short)FontBoldWeight.Normal;
                cellStyle.SetFont(cellfont);

                //建立内容行
                int iRowIndex = 1;
                int iCellIndex = 0;
                foreach (DataRow Rowitem in dt.Rows)
                {
                    IRow DataRow = sheet.CreateRow(iRowIndex);
                    foreach (DataColumn Colitem in dt.Columns)
                    {

                        ICell cell = DataRow.CreateCell(iCellIndex);
                        cell.SetCellValue(Rowitem[Colitem].ToString());
                        cell.CellStyle = cellStyle;
                        iCellIndex++;
                    }
                    iCellIndex = 0;
                    iRowIndex++;
                }

                //自适应列宽度
                for (int i = 0; i < icolIndex; i++)
                {
                    sheet.AutoSizeColumn(i);
                }


                // 写入到客户端   
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                workbook.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms, "application/vnd.ms-excel", fileName + ".xls");

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        /// <summary>
        /// 下载Execl方法 By List<T>
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="list">实体对象List</param>
        /// <param name="fileName">下载的文件名</param>
        /// <returns></returns>
        public FileResult ExportExecl<T>(List<T> list, string fileName)
        {
            DataTable dt = ListToDataTable<T>(list);
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                ICellStyle HeadercellStyle = workbook.CreateCellStyle();
                HeadercellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                HeadercellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                //字体
                NPOI.SS.UserModel.IFont headerfont = workbook.CreateFont();
                headerfont.Boldweight = (short)FontBoldWeight.Bold;
                HeadercellStyle.SetFont(headerfont);


                //用column name 作为列名
                int icolIndex = 0;
                IRow headerRow = sheet.CreateRow(0);
                foreach (DataColumn item in dt.Columns)
                {
                    ICell cell = headerRow.CreateCell(icolIndex);
                    cell.SetCellValue(item.ColumnName);
                    cell.CellStyle = HeadercellStyle;
                    icolIndex++;
                }

                ICellStyle cellStyle = workbook.CreateCellStyle();

                //为避免日期格式被Excel自动替换，所以设定 format 为 『@』 表示一率当成text
                cellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("@");
                cellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                cellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;


                NPOI.SS.UserModel.IFont cellfont = workbook.CreateFont();
                cellfont.Boldweight = (short)FontBoldWeight.Normal;
                cellStyle.SetFont(cellfont);

                //建立内容行
                int iRowIndex = 1;
                int iCellIndex = 0;
                foreach (DataRow Rowitem in dt.Rows)
                {
                    IRow DataRow = sheet.CreateRow(iRowIndex);
                    foreach (DataColumn Colitem in dt.Columns)
                    {

                        ICell cell = DataRow.CreateCell(iCellIndex);
                        cell.SetCellValue(Rowitem[Colitem].ToString());
                        cell.CellStyle = cellStyle;
                        iCellIndex++;
                    }
                    iCellIndex = 0;
                    iRowIndex++;
                }

                //自适应列宽度
                for (int i = 0; i < icolIndex; i++)
                {
                    sheet.AutoSizeColumn(i);
                }


                // 写入到客户端   
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                workbook.Write(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return File(ms, "application/vnd.ms-excel", fileName + ".xls");

            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #endregion

        private static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }


        /// <summary>
        /// 正则匹配测试
        /// </summary>
        /// <returns></returns>
        public string ZhengZePiPei()
        {
            string strURL = "http://www.text.com";
            StringBuilder strContent = new StringBuilder();
            strContent.Append("从创立之<img src=\"../../yy/xx.jpg\" />初，百度便将“让人<img src=\"/yy/xx.jpg\" />们最平等便捷地获取信息，找到所求”作为自己的使命，成立以来，公司秉承“用");
            strContent.Append("从创立之初，百<p>度便将“让人们最平等便捷地获</p>取信息，<img src='https://imgsa.baidu.com/baike/s%3D220/sign=81d5b8ab932397ddd2799f066983b216/2cf5e0fe9925bc31b88d80d45cdf8db1ca1370ae.jpg' />找到所求”作为自己的使命，成立以来，公司秉承“用");

            string str = Regex.Replace(strContent.ToString(), @"(?is)(?<=<IMG\ssrc=""(?!http)).*?[^>](?=/)", strURL);

            return str;
        }

    }


    /// <summary>
    /// 测试用的实体对象
    /// </summary>
    public class TestModel
    {
        //编号
        [Display(Name = "编号", Description = "0")]
        public int ID { get; set; }

        //姓名
        [Display(Name = "姓名", Description = "0")]
        public string Name { get; set; }

        //序列号
        [Display(Name = "序列号", Description = "1")]
        public string SerialNumber { get; set; }

        //文本内容
        [Display(Name = "文本", Description = "0")]
        public string Text { get; set; }

        public string Text1 { get; set; }

        public string Text2 { get; set; }
        public string Text3 { get; set; }
        public string Text4 { get; set; }
        public string Text5 { get; set; }
        public string Text6 { get; set; }

        public string Text11 { get; set; }

        public string Text22 { get; set; }
        public string Text33 { get; set; }
        public string Text44 { get; set; }
        public string Text55 { get; set; }
        public string Text66 { get; set; }

        public string Text111 { get; set; }

        public string Text222 { get; set; }
        public string Text333 { get; set; }
        public string Text444 { get; set; }
        public string Text555 { get; set; }
        public string Text666 { get; set; }

    }


}