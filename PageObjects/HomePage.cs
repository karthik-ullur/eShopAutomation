using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopAutomation.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        By productName = By.CssSelector(".esh-catalog-name");
        By cartBtn = By.CssSelector(".esh-catalog-button");
        By homeScreenDoc = By.CssSelector(".esh-app-wrapper");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = ".esh-identity-name")]
        private IWebElement loginButton;

        [FindsBy(How = How.CssSelector, Using = "#CatalogModel_BrandFilterApplied")]
        private IWebElement brand;

        [FindsBy(How = How.CssSelector, Using = "#CatalogModel_TypesFilterApplied")]
        private IWebElement type;

        [FindsBy(How = How.CssSelector, Using = "input.esh-catalog-send")]
        private IWebElement filterBtn;

        [FindsBy(How = How.CssSelector, Using = ".esh-catalog-item")]
        private IList<IWebElement> items;

        public By getHomeScreenDoc() { return homeScreenDoc; }

        public IWebElement login()
        {
            return loginButton;
        }

        public SelectElement getBrand()
        {
            Thread.Sleep(3000);
                SelectElement selectBrand = new SelectElement(brand);
            return selectBrand;  
        }

        public SelectElement getType()
        {
            Thread.Sleep(3000);
            SelectElement selectType = new SelectElement(type);
            return selectType;
        }
        public IWebElement filterButton()
        {
            Thread.Sleep(3000);
            return filterBtn;
        }

        public IList<IWebElement> getItems()
        {
            return items;
        }

        public By addToCart()
        {
            return cartBtn;
        }

        public By getProductName()
        {
            return productName;
        }
    }
}
