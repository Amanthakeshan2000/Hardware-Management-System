using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishara_Traders
{
    internal class DBConnection
    {
            public string MyConnection()
        {
            string con = "Data Source=DESKTOP-1DA8EH9\\SQLEXPRESS;Initial Catalog=dbs;Integrated Security=True";
            return con;
        }
    }
}
