using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class Homepage : WebpageBase
    {
        IWebElement UsernameField => this.driver.FindElement(By.Id("user-name"));
        IWebElement PasswordField => this.driver.FindElement(By.Id("password"));
        IWebElement SignInLink => driver.FindElement(By.Id("login-button"));
        IWebElement Alert => this.driver.FindElement(By.Id("login_button_container"));

        public Homepage(IWebDriver driver) : base(driver, ApplicationConfigurationReader.SignInPageURL)
        {

        }

        internal void InputUsername(string username)
        {
            UsernameField.SendKeys(username);
        }
        internal void InputPassword(string password)
        {
            PasswordField.SendKeys(password);
        }

        internal void ClickSignInLink()
        {
            SignInLink.Click();
        }
        internal string GetAlertText()
        {
            Thread.Sleep(5000);
            return Alert.Text;
        }
    }
}
