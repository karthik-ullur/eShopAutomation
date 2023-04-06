using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class PaymentPage
    {
        IWebDriver driver;

        public PaymentPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "input[type='submit']")]
        private IWebElement payBtn;

        public IWebElement payNow()
        {
            return payBtn;
        }
    }
}
