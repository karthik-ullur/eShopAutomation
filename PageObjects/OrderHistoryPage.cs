using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class OrderHistoryPage
    {
        private IWebDriver driver;
        public OrderHistoryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/article[10]/section[5]/a[1]")]
        private IWebElement details;

        public IWebElement getDetails()
        {
            return details;
        }
    }
}
