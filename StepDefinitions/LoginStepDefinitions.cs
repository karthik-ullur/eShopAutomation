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
        HomePage homePage;
            LoginPage loginPage;

        public LoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [Given(@"I navigate to main page")]
        public void GivenINavigateToURL()
        {
            driver.Url = "https://localhost:44315/";
        }

        [Then(@"Goto Login page")]
        public void WhenGotoLoginPage()
        {
           homePage = new HomePage(driver);
            homePage.login().Click();
        }

        [When(@"Enter login details '([^']*)' and '([^']*)'")]
        public void ThenEnterLoginDetailsAnd(string username, string password)
        {
             loginPage = new LoginPage(driver);
            loginPage.getEmailId().SendKeys(username);
            loginPage.getPassword().SendKeys(password);
            loginPage.getLoginIn().Click();
        }
        [Then(@"Check for successful login")]
        public void ThenCheckForSuccessfulLogin()
        {
            homePage = new HomePage(driver);
            string loggedUserName = homePage.getUserName().Text;
            if (loggedUserName != "LOGIN")
            {
                Console.WriteLine("Login Success");
            }
        }
        [Then(@"check Invalid error message")]
        public void ThenCheckInvalidErrorMessage()
        {
            loginPage = new LoginPage(driver);
            bool error = loginPage.getErrorMessage().Displayed;
            if (error == true)
            {
                Console.WriteLine("Invalid Input");
            }
        }


    }
}