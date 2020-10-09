using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite.BDD
{
    [Binding, Scope(Tag = "Inventory")]
    public class InventorySteps
    {
        string itemName = string.Empty;
        string itemURL = string.Empty;

        public Website Website { get; } = new Website("chrome");

        [Given(@"I am on the inventory page")]
        public void GivenIAmOnTheInventoryPage()
        {
            Website.Inventory.VisitThisPage();
        }

        [When(@"When I click the link for item (.*)")]
        public void WhenWhenIClickTheLinkForItem(int HTMLChildNumber)
        {
            itemName = Website.Inventory.ItemName(HTMLChildNumber);
            itemURL = Website.Inventory.ItemLink(HTMLChildNumber).Text;

            Website.Inventory.ClickItemLink(HTMLChildNumber);   
        }
        
        [Then(@"I am taken to to the page for item (.*)")]
        public void ThenIAmTakenToToThePageForItem(int HTMLChildNumber)
        {
            Website.SetInventoryItemObject(itemURL);
            string itemDisplayed = Website.InventoryItem.ItemName;

            Assert.That(itemDisplayed, Is.EqualTo(itemName));
        }
    }
}
