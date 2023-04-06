using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class OrderConfirmationPage
    {
        private IWebDriver driver;

        public OrderConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.container h1")]
        private IWebElement confirmMessage;

        [FindsBy(How = How.XPath, Using = "//section[2]/a[1]")]
        private IWebElement myOrders;

        [FindsBy(How = How.CssSelector, Using = "section.esh-identity-section")]
        private IWebElement accInfo;

        [FindsBy(How = How.PartialLinkText, Using = "Continue Shopping...")]
        private IWebElement continueShopping;

        public IWebElement getConfirmationMessage()
        {
            return confirmMessage;
        }

        public IWebElement getMyOrders()
        {
            return myOrders;
        }

        public IWebElement getAccDetails()
        {
            return accInfo;
        }

        public IWebElement getContinueShopping()
        {
            return continueShopping;
        }
    }
}
