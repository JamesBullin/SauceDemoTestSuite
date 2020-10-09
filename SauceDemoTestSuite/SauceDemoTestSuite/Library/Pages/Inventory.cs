using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoTestSuite
{
    public class Inventory : WebpageBase
    {
        public IWebElement InventoryItems => this.driver.FindElement(By.Id("inventory_container"));
        public IWebElement ShoppingCartBadge => this.driver.FindElement(By.CssSelector(".shopping_cart_badge"));

        public IWebElement ItemLink(int HTMLChildNumber) => GetItem(HTMLChildNumber).FindElement(By.CssSelector(".inventory_item_name"));
        public IWebElement ItemAddButton(int HTMLChildNumber) => GetItem(HTMLChildNumber).FindElement(By.CssSelector(".btn_primary"));
        public IWebElement ItemRemoveButton(int HTMLChildNumber) => GetItem(HTMLChildNumber).FindElement(By.CssSelector(".btn_secondary"));

        public string ItemName(int HTMLChildNumber) => ItemLink(HTMLChildNumber).Text;

        public Inventory(IWebDriver driver) : base(driver, ApplicationConfigurationReader.InventoryPageURL)
        {

        }

        internal void AddToCart(int HTMLChildNumber)
        {
            ItemAddButton(HTMLChildNumber).Click();
        }

        internal void RemoveFromCart(int HTMLChildNumber)
        {
            ItemRemoveButton(HTMLChildNumber).Click();
        }

        internal void ClickItemLink(int HTMLChildNumber)
        {
            ItemLink(HTMLChildNumber).Click();
        }

        IWebElement GetItem(int HTMLChildNumber)
        {
            return InventoryItems.FindElement(By.CssSelector($".inventory_item:nth-child({HTMLChildNumber})"));
        }


    }
}
