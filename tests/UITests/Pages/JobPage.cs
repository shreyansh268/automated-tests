using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using UITests.Interface;

namespace UITests.Pages
{
    public class JobPage : IPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        #region locators

        private const string ClassJobTitle = "jobtitle";

        #endregion locators

        public JobPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public bool IsPageDisplayed()
        {
            var title = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(ClassJobTitle)));
            return title.Displayed;
        }

        public string GetTitle()
        {
            var title = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(ClassJobTitle)));
            return title.Text;
        }
    }
}