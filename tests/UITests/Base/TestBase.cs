using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace UITests.Base
{
    public class TestBase
    {
        protected IWebDriver _driver;
        private ExtentReports _extentReports;

        [TestInitialize]
        public void Initialize()
        {
            Init();
            InitReport();
        }

        /// <summary>
        /// Initialize test html report
        /// </summary>
        private void InitReport()
        {
            var reportPath = Environment.CurrentDirectory + @"\Report\TestReport.html";
            var htmlReport = new ExtentHtmlReporter(reportPath);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReport);
        }

        /// <summary>
        /// Open chrome browser and navigate to url
        /// </summary>
        private void Init()
        {
            InitChromeDriverManager();
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.agdata.com/");
            _driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Set up chrome driver using webdriver manager utility
        /// </summary>
        private static void InitChromeDriverManager()
        {
            var config = new ChromeConfig();
            var matchingVersion = config.GetMatchingBrowserVersion();
            new DriverManager().SetUpDriver(config, matchingVersion);
        }

        [TestCleanup]
        public void Quit()
        {
            if (_driver != null)
            {
                _driver.Quit();
            }
            if (_extentReports != null)
            {
                _extentReports.Flush();
            }
        }
    }
}