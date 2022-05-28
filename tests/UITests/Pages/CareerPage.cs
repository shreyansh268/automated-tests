using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using UITests.Interface;

namespace UITests.Pages
{
    public class CareerPage : IPage
    {
        #region elements
        [FindsBy(How = How.CssSelector, Using = "ul.jobs li>span.job a")]
        private IWebElement JobTitle;

        #endregion elements
        public bool IsPageDisplayed()
        {
            throw new System.NotImplementedException();
        }

        
    }
}