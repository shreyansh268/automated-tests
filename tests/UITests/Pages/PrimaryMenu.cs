﻿using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using UITests.Interface;

namespace UITests.Pages
{
    public class PrimaryMenu : IPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public PrimaryMenu(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
        }

        public bool IsPageDisplayed()
        {
            throw new NotImplementedException();
        }

        public void NavigateToCareers()
        {
            var companyLink = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("menu-item-992")));
            new Actions(_driver).MoveToElement(companyLink).Build().Perform();
            var careerLink = _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("menu-item-269")));
            careerLink.Click();
        }
    }
}