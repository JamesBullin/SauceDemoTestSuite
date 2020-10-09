using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class WebpageBase
    {
        protected readonly IWebDriver driver;

        public string URL { get; set; }

        public WebpageBase(IWebDriver driver, string URL)
        {
            this.driver = driver;
            this.URL = URL;
        }

        public void VisitThisPage()
        {
            driver.Navigate().GoToUrl(URL);
        }

        internal string GetURL()
        {
            Thread.Sleep(3000);
            return driver.Url;
        }

        internal string GetPageTitle()
        {
            return driver.Title;
        }
    }
}
