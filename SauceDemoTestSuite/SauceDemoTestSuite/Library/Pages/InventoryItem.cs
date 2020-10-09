using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class InventoryItem : WebpageBase
    {
        public InventoryItem(IWebDriver driver, string URL) : base(driver, URL)
        {

        }
        public string ItemName => this.driver.FindElement(By.CssSelector(".inventory_details_name")).Text;
    }
}
