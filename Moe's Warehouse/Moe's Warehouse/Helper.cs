using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KernalPanic
{
    class Helper
    {
        public static string ConnectVal(string connectName)
        {
            return ConfigurationManager.ConnectionStrings[connectName].ConnectionString;
        }
    }
}
