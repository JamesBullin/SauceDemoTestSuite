using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SauceDemoTestSuite
{
    [Binding, Scope(Tag = "Cart")]
    public class CartSteps
    {
        public Website Website { get; } = new Website("chrome");

        [Given(@"I am on the inventory page")]
        public void GivenIAmOnTheInventoryPage()
        {
            Website.Inventory.VisitThisPage();
        }

        [When(@"I click Add To Cart for (.*) items")]
        public void WhenIClickAddToCartForItems(int numItemsClicked)
        {
            for (int i = 1; i <= numItemsClicked; i++)
            {
                Website.Inventory.AddToCart(i);
            }
        }

        [Given(@"I click Add To Cart for (.*) items")]
        public void GivenIClickAddToCartForItems(int numItemsClicked)
        {
            WhenIClickAddToCartForItems(numItemsClicked);
        }

        [When(@"I click Remove for (.*) items")]
        public void WhenIClickRemoveForItems(int numItemsRemoved)
        {
            for (int i = 1; i <= numItemsRemoved; i++)
            {
                Website.Inventory.RemoveFromCart(i);
            }
        }

        [Then(@"The icon shows (.*) items have been added to the cart")]
        public void ThenTheIconShowsItemsHaveBeenAddedToTheCart(int expectedNumItems)
        {
            Assert.That(Int32.Parse(Website.Inventory.ShoppingCartBadge.Text), Is.EqualTo(expectedNumItems));
        }
    }
}
