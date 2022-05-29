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

        /// <summary>
        /// Check if job detail page is displayed
        /// </summary>
        /// <returns>True is displayed</returns>
        public bool IsPageDisplayed()
        {
            var title = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(ClassJobTitle)));
            return title.Displayed;
        }

        /// <summary>
        /// Get title of job
        /// </summary>
        /// <returns>Title of the job</returns>
        public string GetTitle()
        {
            var title = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName(ClassJobTitle)));
            return title.Text;
        }
    }
}