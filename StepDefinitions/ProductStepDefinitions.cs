using eShopAutomation.PageObjects;
using eShopAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Assist;

namespace eShopAutomation.StepDefinitions
{
    [Binding]
    public sealed class ProductStepDefinitions
    {
        IWebDriver driver;
        
        public ProductStepDefinitions(IWebDriver driver) 
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Given(@"navigate to main page '([^']*)'")]
        public void GivenNavigateToMainPage(string uri)
        {
            driver.Url = uri;
        }

        [When(@"Enter Login details")]
        public void WhenEnterLoginDetails(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);

            HomePage homePage = new HomePage(driver);
            LoginPage loginPage = new LoginPage(driver);
            homePage.login().Click();

            //Logging with valid Username and Password
            loginPage.getEmailId().SendKeys(dictionary["Username"]);
            loginPage.getPassword().SendKeys(dictionary["Password"]);
            loginPage.getLoginIn().Click();
            string actualTitle = driver.Title;
            string expectedTitle = "Catalog - Microsoft.eShopOnWeb";
            try
            {
                if (actualTitle != expectedTitle)
                    throw new Exception();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString() + "Invalid");
            }
        }

        [Then(@"Filter the Products '([^']*)' and '([^']*)'")]
        public void ThenFilterTheProductsAnd(string brand, string type)
        {
           
            HomePage homePage = new HomePage(driver);
            homePage.getBrand().SelectByText(brand);
            homePage.getType().SelectByText(type);
            homePage.filterButton().Click();   
        }


        [Then(@"select the product and add it to cart")]
        public void ThenSelectTheProductAndAddItToCart()
        {
            string[] expectedProduct = { "ROSLYN RED SHEET" };
            HomePage homePage = new HomePage(driver);
            CheckOutPage checkOutPage = new CheckOutPage(driver);
            IList<IWebElement> products = homePage.getItems();
            foreach (IWebElement product in products)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                if (expectedProduct.Contains(product.FindElement(homePage.getProductName()).Text))
                {
                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                    //Add to cart
                    product.FindElement(homePage.addToCart()).Click();
                    break;
                }
            }
        }


        [Then(@"Go to checkout page and select the quantity and checkout")]
        public void ThenGoToCheckoutPageAndSelectTheQuantityAndCheckout()
        {
            // Checking out the product
            CheckOutPage checkOutPage = new CheckOutPage(driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            Thread.Sleep(3000);

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(getFooter()));
            checkOutPage.checkOutBtn().Click();
        }

        [Then(@"make a payment")]
        public void ThenMakeAPayment()
        {
            PaymentPage paymentPage = new PaymentPage(driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
             Thread.Sleep(3000);
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(getFooter()));
            paymentPage.payNow().Click();
        }

        [Then(@"check for order confirmation message")]
        public void ThenCheckForOrderConfirmationMessage()
        {
            //verifying Ordered Details
            string expectedMessage = "Thanks for your Order!";
            OrderConfirmationPage orderConfirmationPage = new OrderConfirmationPage(driver);
            string actualMessage = orderConfirmationPage.getConfirmationMessage().Text;
            Assert.AreEqual(expectedMessage, actualMessage);
        }

       [Then(@"ordering multiple products")]
        public void ThenOrderingMultipleProducts()
        {
            string[] expectedProducts = { ".NET BOT BLACK SWEATSHIRT", ".NET BLACK & WHITE MUG", "PRISM WHITE T-SHIRT" };
            HomePage homePage = new HomePage(driver);
            CheckOutPage checkOutPage = new CheckOutPage(driver);
            OrderConfirmationPage orderConfirmationPage = new OrderConfirmationPage(driver);
            orderConfirmationPage.getContinueShopping().Click();

            //Ordering multiple products
            IList<IWebElement> products = homePage.getItems();
            foreach (IWebElement product in products)
            {
                //Thread.Sleep(3000);
                if (expectedProducts.Contains(product.FindElement(homePage.getProductName()).Text))
                {
                    // Thread.Sleep(3000);
                    //Add to cart
                    product.FindElement(homePage.addToCart()).Click();
                    ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    Thread.Sleep(3000);
                    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(homePage.getHomeScreenDoc()));
                    checkOutPage.getContinueShop().Click();
                }


            }
        }

    }
}