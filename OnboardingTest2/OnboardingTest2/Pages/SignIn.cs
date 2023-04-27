using AventStack.ExtentReports;
using NUnit.Framework;
using OnboardingTest2.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ReportUtils.Reports;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingTest2.Pages
{
    public class SignIn
    {
        public void SignInActions(IWebDriver driver, string emailaddress, string password)
        {
            ExtentReporting.LogInfo($"Sign in with vaild credentials!");

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 5);
            // Identify the Sign In button and click on it
            IWebElement signInButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signInButton.Click();

            // Identify the Email address textbox and enter vaild email address
            IWebElement emailTextbox = driver.FindElement(By.XPath("//input[@name=\"email\"]"));
            emailTextbox.SendKeys(emailaddress);

            // Identify the Password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.XPath("//input[@name=\"password\"]"));
            passwordTextbox.SendKeys(password);

            // Identify the Login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();

            Thread.Sleep(5000);
            // Assert if the account has been sign in
            Wait.WaitToBeVisible(driver, "XPath", "//div[contains(text(), \"Eddie He\")]", 5);
            IWebElement actualAccountName = driver.FindElement(By.XPath("//div[contains(text(), \"Eddie He\")]"));
            Assert.That(actualAccountName.Text == "Eddie He", "Actual name and expected name do not match!");
        }
    }
}
