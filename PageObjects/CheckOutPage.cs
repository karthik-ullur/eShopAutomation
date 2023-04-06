using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class CheckOutPage
    {
        private IWebDriver driver;

        public CheckOutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[text()='[ Checkout ]']")]
        private IWebElement checkOut;

        [FindsBy(How = How.XPath, Using = "//a[text()='[ Continue Shopping ]']")]
        private IWebElement continueShop;

        public IWebElement checkOutBtn()
        {
            return checkOut;
        }

        public IWebElement getContinueShop()
        {
            return continueShop;
        }
    }
}
