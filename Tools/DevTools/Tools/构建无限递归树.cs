using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Tools
{
   public class 构建无限递归树
    {



        public string 调用()
        {

            List<BootstrapTree> allBoottree = new List<BootstrapTree>();
            //获取所有节点的数据
            allBoottree = GetLoadList();

            JavaScriptSerializer js = new JavaScriptSerializer();
            BootstrapTree bootStarp = new BootstrapTree();
            //递归获取子功能树
            GetChildren(allBoottree, bootStarp);
            return js.Serialize(bootStarp);
        }

        /// <summary>
        /// 递归获取子功能树
        /// </summary>
        /// <param name="listData">全部功能树节点</param>
        /// <param name="curentItem">当前功能树对象</param>
        public void GetChildren(List<BootstrapTree> listData, BootstrapTree curentItem)
        {
            var subItems = listData.Where(ee => ee.ParentID == curentItem.ID).ToList();
            curentItem.nodes = new List<BootstrapTree>();
            curentItem.nodes.AddRange(subItems);
            foreach (var subItem in subItems)
            {
                GetChildren(listData, subItem);
            }
        }

        /// <summary>
        /// 
        /// 模拟数据
        /// 
        /// -------------模拟结果如下-----------------
        /// 
        ///             第一级别
        ///                第一子级别01
        ///                    第一孙子级别01
        ///                         第一曾孙子级别01
        ///                         第一曾孙子级别02
        ///                    第一孙子级别02
        ///                第一子级别02
        ///                第一子级别03
        ///             第二级别
        ///                第二子级别01
        ///                第二子级别02
        ///             第三级别
        ///   
        /// --------------------------------------------
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BootstrapTree> GetLoadList()
        {
            List<BootstrapTree> lst = new List<BootstrapTree>();
            BootstrapTree mBoot = new BootstrapTree();

            //root级别
            mBoot.ID = 1;
            mBoot.ParentID = 0;
            mBoot.text = "第一级别";
            mBoot.Level = 1;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 2;
            mBoot.ParentID = 0;
            mBoot.text = "第二级别";
            mBoot.Level = 1;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 3;
            mBoot.ParentID = 0;
            mBoot.text = "第三级别";
            mBoot.Level = 1;
            mBoot.href = "#";
            lst.Add(mBoot);

            //第一子级别
            mBoot = new BootstrapTree();
            mBoot.ID = 4;
            mBoot.ParentID = 1;
            mBoot.text = "第一子级别01";
            mBoot.Level = 2;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 5;
            mBoot.ParentID = 1;
            mBoot.text = "第一子级别02";
            mBoot.Level = 2;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 6;
            mBoot.ParentID = 1;
            mBoot.text = "第一子级别03";
            mBoot.Level = 2;
            mBoot.href = "#";
            lst.Add(mBoot);

            //第一孙子级别01
            mBoot = new BootstrapTree();
            mBoot.ID = 7;
            mBoot.ParentID = 4;
            mBoot.text = "第一孙子级别01";
            mBoot.Level = 3;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 8;
            mBoot.ParentID = 4;
            mBoot.text = "第一孙子级别02";
            mBoot.Level = 3;
            mBoot.href = "#";
            lst.Add(mBoot);

            //第二子级别
            mBoot = new BootstrapTree();
            mBoot.ID = 9;
            mBoot.ParentID = 2;
            mBoot.text = "第二子级别01";
            mBoot.Level = 2;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 10;
            mBoot.ParentID = 2;
            mBoot.text = "第二子级别02";
            mBoot.Level = 2;
            mBoot.href = "#";
            lst.Add(mBoot);

            //第一节点的孙子节点
            mBoot = new BootstrapTree();
            mBoot.ID = 11;
            mBoot.ParentID = 7;
            mBoot.text = "第一曾孙子级别01";
            mBoot.Level = 3;
            mBoot.href = "#";
            lst.Add(mBoot);

            mBoot = new BootstrapTree();
            mBoot.ID = 12;
            mBoot.ParentID = 7;
            mBoot.text = "第一曾孙子级别02";
            mBoot.Level = 3;
            mBoot.href = "#";
            lst.Add(mBoot);

            return lst;
        }



    }

    /// <summary>
    /// 功能树实体类
    /// </summary>
    public class BootstrapTree
    {
        public int ID { get; set; }

        public int ParentID { get; set; }

        public int Level { get; set; }

        public string text { get; set; }

        public string href { get; set; }

        public List<BootstrapTree> nodes { get; set; }

    }
}
