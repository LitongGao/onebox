using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestParse
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(GetMgmtSystemEnumByName("123Pet"));
            Console.WriteLine(DateTime.UtcNow.ToString("o"));
            Console.WriteLine(DateTime.UtcNow.ToString());
            Console.WriteLine(Environment.CurrentDirectory.ToString());
            string a= Environment.CurrentDirectory.ToString();
            a = Path.GetDirectoryName(a);
            Console.WriteLine(a);
            a = Path.GetDirectoryName(a);
            Console.WriteLine(a);
            Console.ReadKey();
        }
        public static SupportPMS GetMgmtSystemEnumByName(string sysName)
        {
            string displayName = sysName.Replace(' ', '_').Replace('/', '4')
                .Replace('-', '5').Replace('.', '6');
            Console.WriteLine("Displayname is: {0}", displayName);
            int firstChar;
            if (Int32.TryParse(displayName.Substring(0, 1), out firstChar))
            {
                return (SupportPMS)Enum.Parse(typeof(SupportPMS), "_" + displayName);
            }
            else
            {
                return (SupportPMS)Enum.Parse(typeof(SupportPMS), displayName);
            }
        }
    }
}
