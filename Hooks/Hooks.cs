using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using eShopAutomation.Utilities;

namespace eShopAutomation.Hooks
{
    [Binding]
    public sealed class Hooks : Base
    {
        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {

            // Invoking browser
            StartBrowser();
            driver.Manage().Window.Maximize();

            // Make this instance available to all other step definitions
            _container.RegisterInstanceAs(driver);
        }

        //  [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();
            if (driver != null)
            {
                Thread.Sleep(2000);
                driver.Close();
            }
        }
    }
}