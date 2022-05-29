using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            menu.NavigateToCareers();

            var careerPage = new CareerPage(_driver);
            var posting = careerPage.NavigateToSecondManagerPosting();

            var jobPage = new JobPage(_driver);
            var actualPosting = jobPage.GetTitle();
            Assert.AreEqual(posting, actualPosting, "Actual job title is not as expected");
        }
    }
}