using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using CompetitionTask.Utilites;
using MongoDB.Bson.Serialization.Conventions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OnboardingTest2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V110.Debugger;
using ReportUtils.Reports;
using System.Reflection;
using System.Security.Policy;

namespace OnboardingTest2.Utilites
{
    [TestFixture]
    public class CommonDriver
    {
        public static WebDriver driver;
        protected Broswer Broswer;

        [SetUp]
        public void OpenBrowser()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");
              
            Broswer = new Broswer(driver);
        }


        [TearDown]
        public void CloseBrowser()
        {
            EndTest();
            ExtentReporting.EndReporting();
            driver.Close();         
        }                 
        
        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch(testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test skipped {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenShot("Ending test", Broswer.GetScreenShot());
        }
    }
}
