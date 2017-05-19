using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = ",\"1\",";
            string[] strArr = str.Trim(',').Split(',');
            string newStr = string.Empty;
            for (int i = 0; i < strArr.Length; i++)
            {
                
                Console.WriteLine("'"+ strArr[i].Trim('"')+ "'");
                newStr +=","+"'" + strArr[i].Trim('\'').Trim('"') + "'";
            }
            Console.WriteLine(newStr.Trim(','));
            Console.ReadKey();
        }

        public static List<Personlist> getList()
        {
            Personlist p = new Test.Personlist();
            List<Personlist> listp = new List<Test.Personlist>();
            for (int i = 0; i < 10; i++)
            {
                p = new Test.Personlist();
                p.name = "张三";
                p.address = "武汉";
                p.fullname = i.ToString();
                p.age = i;
                listp.Add(p);
            }
            return listp;
        }
    }


    public class Person
    {
        public string name { get; set; }
      
        public string address { get; set; }
  
    }
    public class Personlist
    {
        public string name { get; set; }
        public int age { get; set; }
        public string address { get; set; }
        public string fullname { get; set; }
    }

}
