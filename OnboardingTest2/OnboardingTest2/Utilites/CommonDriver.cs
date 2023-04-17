using NUnit.Framework;
using OnboardingTest2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingTest2.Utilites
{
    public class CommonDriver
    {
        public static WebDriver driver;

        [SetUp]
        public void LoginSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/Home");

            // Login action
            SignIn signIn = new SignIn();
            signIn.SignInActions(driver);
        }

        [TearDown]
        public void CloseBrowsers()
        {
            driver.Quit();
        }
    }
}
