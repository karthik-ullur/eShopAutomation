using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#Input_Email")]
        private IWebElement emaliId;

        [FindsBy(How = How.CssSelector, Using = "input[name='Input.Password']")]
        private IWebElement password;

        [FindsBy(How = How.XPath, Using = "//div/button[@type='submit']")]
        private IWebElement loginIn;

       public IWebElement getEmailId()
        {
            return emaliId;
        }

        public IWebElement getPassword()
        {
            return password;
        }

        public IWebElement getLoginIn()
        {
            return loginIn;
        }

    }
}
