using System.Configuration;

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
