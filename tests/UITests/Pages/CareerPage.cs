using OpenQA.Selenium;
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

        public bool IsPageDisplayed()
        {
            var careerHeader = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.TagName("h1")));
            return careerHeader.Displayed;
        }

        public void NavigateToSecondManagerPosting()
        {
            SwitchToFrame();
            var allManagerPostings = GetAllManagerJobs();
            allManagerPostings[1].Click();
            SwitchToDefault();
        }

        private void SwitchToFrame()
        {
            var frame = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(IdFrame)));
            _driver.SwitchTo().Frame(frame);
        }

        private void SwitchToDefault()
        {
            _driver.SwitchTo().DefaultContent();
        }

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