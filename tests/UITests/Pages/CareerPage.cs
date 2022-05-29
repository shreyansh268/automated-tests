using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UITests.Interface;

namespace UITests.Pages
{
    public class CareerPage : IPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        #region locators

        private const string CssJobTitle = "#aspnetForm span.job a";
        private const string IdFrame = "HBIFRAME";

        #endregion locators

        public CareerPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Check if career page is displayed
        /// </summary>
        /// <returns>True if displayed</returns>
        public bool IsPageDisplayed()
        {
            var careerHeader = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h1")));
            return careerHeader.Displayed;
        }

        /// <summary>
        /// Navigate to second manager posting from career page
        /// </summary>
        /// <returns>Title of the job being navigated to</returns>
        public string NavigateToSecondManagerPosting()
        {
            SwitchToFrame();
            var allManagerPostings = GetAllManagerJobs();
            var posting = allManagerPostings[1];
            var title = posting.Text;
            new Actions(_driver).MoveToElement(posting).Build().Perform();
            _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(posting)).Click();
            return title;
        }

        /// <summary>
        /// Switch to main iframe
        /// </summary>
        private void SwitchToFrame()
        {
            var frame = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(IdFrame)));
            _driver.SwitchTo().Frame(frame);
        }

        /// <summary>
        /// Switch to default frame on page
        /// </summary>
        private void SwitchToDefault()
        {
            _driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// Get all manger job listing elements on career page
        /// </summary>
        /// <returns>List of manager job listing web elements</returns>
        /// <exception cref="NoSuchElementException"></exception>
        private List<IWebElement> GetAllManagerJobs()
        {
            var list = new List<IWebElement>();
            foreach (var jobElement in GetAllJobs())
            {
                if (jobElement.Text.ToLower().Contains("manager"))
                {
                    list.Add(jobElement);
                }
            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                throw new NoSuchElementException("Manager jobs not found on career page");
            }
        }

        /// <summary>
        /// Get all job listings on career page
        /// </summary>
        /// <returns>List of all job listing web elements</returns>
        /// <exception cref="NoSuchElementException"></exception>
        /// <exception cref="ElementNotVisibleException"></exception>
        private ReadOnlyCollection<IWebElement> GetAllJobs()
        {
            if (IsPageDisplayed())
            {
                var jobList = _driver.FindElements(By.CssSelector(CssJobTitle));
                if (jobList.Count > 0)
                {
                    return jobList;
                }
                else
                {
                    throw new NoSuchElementException("No jobs found on career page");
                }
            }
            else
            {
                throw new ElementNotVisibleException("Career page not displayed");
            }
        }
    }
}