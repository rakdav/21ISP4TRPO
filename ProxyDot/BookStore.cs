using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyDot
{
    internal class BookStore : IBook
    {
        ModelDB db;

        public BookStore()
        {
            db=new ModelDB();
        }

        public Page GetPage(int number)
        {
            return db.Page.FirstOrDefault(x => x.Number == number);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
