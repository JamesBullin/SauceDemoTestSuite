using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public static class ApplicationConfigurationReader
    {
        public static readonly string BaseURL = ConfigurationManager.AppSettings["base_url"];
        public static readonly string SignInPageURL = ConfigurationManager.AppSettings["signin_url"];
        public static readonly string InventoryPageURL = ConfigurationManager.AppSettings["inventory_url"];
    }
}
