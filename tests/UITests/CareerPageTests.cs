using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumExtras.PageObjects;
using UITests.Base;
using UITests.Pages;

namespace UITests
{
    [TestClass]
    public class CareerPageTests : TestBase
    {
        [TestMethod]
        public void CareerTest()
        {
            var menu = new PrimaryMenu(_driver);
            PageFactory.InitElements(_driver, menu);
            menu.NavigateToCareers();
        }
    }
}