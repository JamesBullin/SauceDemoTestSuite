using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class Website
    {
        public IWebDriver SeleniumDriver { get; internal set; }

        #region Web Pages
        public Homepage Homepage { get; internal set; }
        public Inventory Inventory { get; internal set; }
        public InventoryItem InventoryItem { get; private set; }

        #endregion

        public Website(string driverName, int pageLoadWaitInSeconds = 10, int implicitWaitInSeconds = 10)
        {
            SeleniumDriver = new SeleniumDriverConfiguration(driverName, pageLoadWaitInSeconds, implicitWaitInSeconds).Driver;
            
            Homepage = new Homepage(SeleniumDriver);
            Inventory = new Inventory(SeleniumDriver);
        }

        public void DeleteCookies()
        {
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();
        }

        public void SetInventoryItemObject(string URL)
        {
            InventoryItem = new InventoryItem(SeleniumDriver, URL);
        }
    }
}
