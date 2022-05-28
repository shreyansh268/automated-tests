using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using UITests.Interface;

namespace UITests.Pages
{
    public class PrimaryMenu : IPage
    {
        private readonly IWebDriver _driver;
        #region elements
        [FindsBy(How = How.LinkText, Using = "Company")]
        private IWebElement CompanyLink;

        [FindsBy(How = How.LinkText, Using = "Careers")]
        private IWebElement CareersLink;

        #endregion elements

        public PrimaryMenu(IWebDriver driver)
        {
            _driver = driver;
        }
        public bool IsPageDisplayed()
        {
            throw new NotImplementedException();
        }

        public void NavigateToCareers()
        {
            new Actions(_driver).MoveToElement(CompanyLink).Build().Perform();
            CareersLink.Click();
        }
    }
}