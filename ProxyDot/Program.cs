using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (IBook book=new BookStoreProxy())
            {
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);
                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);
                //page1 = book.GetPage(1);
                //Console.WriteLine(page1.Text);
                Console.ReadKey();
            }

        }
    }
}
