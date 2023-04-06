using eShopAutomation.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow.Assist;

namespace eShopAutomation.StepDefinitions
{
    [Binding]
    public sealed class LoginStepDefinitions
    {
        IWebDriver driver;

        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Given(@"I navigate to URL")]
        public void GivenINavigateToURL()
        {
            driver.Url = "https://localhost:44315/";
        }

        [When(@"Goto Login page")]
        public void WhenGotoLoginPage()
        {
            HomePage homePage = new HomePage(driver);
            homePage.login().Click();
        }

        [Then(@"Enter login details '([^']*)' and '([^']*)'")]
        public void ThenEnterLoginDetailsAnd(string username, string password)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.getEmailId().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginIn().Click();
        }
    }
}