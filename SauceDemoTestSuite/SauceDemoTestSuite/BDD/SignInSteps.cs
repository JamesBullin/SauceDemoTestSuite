using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.BDD
{
    [Binding, Scope(Tag = "SignIn")]
    public class SignInSteps
    {
        public Website Website { get; } = new Website("chrome");

        [Given(@"I am on the Sign In page")]
        public void GivenIAmOnTheSignInPage()
        {
            Website.Homepage.VisitThisPage();
        }

        [Given(@"I have entered the username (.*)")]
        public void GivenIHaveEnteredTheUsername(string username)
        {
            Website.Homepage.InputUsername(username);
        }

        [Given(@"I have entered the password (.*)")]
        public void GivenIHaveEnteredThePassword(string password)
        {
            Website.Homepage.InputPassword(password);
        }

        [When(@"I click the Log In button")]
        public void WhenIClickTheLogInButton()
        {
            Website.Homepage.ClickSignInLink();
        }

        [Then(@"I will be taken to the Inventory page")]
        public void ThenIWillBeTakenToTheInventoryPage()
        {
            Assert.That(Website.Homepage.GetURL(), Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Then(@"I will see an error message containing ""(.*)""")]
        public void ThenIWillSeeAnErrorMessageContaining(string expectedMessage)
        {
            Assert.That(Website.Homepage.GetAlertText(), Does.Contain(expectedMessage));
        }

    }
}
