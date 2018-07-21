using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class Constants
    {

        public static string ConnectionString
        {
            get
            {
                return @"Data Source=KIWSAN\MSSQLSERVER2017;Initial Catalog=SampleDatabase;Integrated Security=True";
            }
        }

    }
}
