using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class SeleniumDriverConfiguration
    {
        public IWebDriver Driver { get; set; }

        public SeleniumDriverConfiguration(string driver, int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            DriverSetUp(driver, pageLoadInSeconds, implicitWaitInSeconds);
        }

        public void DriverSetUp(string driver, int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            if (driver.ToLower() == "chrome")
            {
                //Creates new diver instance of chrome we can use to test
                SetChromeDriver();
                SetDriverConfiguration(pageLoadInSeconds, implicitWaitInSeconds);
            }
            else if (driver.ToLower() == "firefox")
            {
                SetFireFoxDriver();
                SetDriverConfiguration(pageLoadInSeconds, implicitWaitInSeconds);
            }
            else
            {
                throw new Exception("Please use Chrome or Firefox");
            }
        }

        private void SetFireFoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("headless");
            Driver = new FirefoxDriver(options);
        }

        private void SetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            Driver = new ChromeDriver(options);

        }

        public void SetDriverConfiguration(int pageLoadInSeconds, int implicitWaitInSeconds)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSeconds);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSeconds);
        }
    }
}
