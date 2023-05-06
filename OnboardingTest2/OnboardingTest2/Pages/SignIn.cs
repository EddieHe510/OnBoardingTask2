using AventStack.ExtentReports;
using CompetitionTask.Utilites;
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
    public class SignIn : CommonDriver
    {       
        private IWebElement signInbutton => driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
        private IWebElement emailTextBox => driver.FindElement(By.XPath("//input[@name=\"email\"]"));
        private IWebElement passwordTextBox => driver.FindElement(By.XPath("//input[@name=\"password\"]"));
        private IWebElement loginButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
        private IWebElement actualAccountName => driver.FindElement(By.XPath("//div[contains(text(), \"Eddie He\")]"));


        public void SignInActions(string emailAddress, string password)
        {
            ExtentReporting.LogInfo($"Sign in with vaild credentials!");

            // Identify the Sign In button and click on it          
            signInbutton.Click();

            // Identify the Email address textbox and enter vaild email address
            emailTextBox.SendKeys(emailAddress);

            // Identify the Password textbox and enter valid password
            passwordTextBox.SendKeys(password);

            // Identify the Login button and click on it
            loginButton.Click();

            Thread.Sleep(3000);
            // Assert if the account has been sign in
            Wait.WaitToBeVisible(driver, "XPath", "//div[contains(text(), \"Eddie He\")]", 5);           
            Assert.That(actualAccountName.Text == "Eddie He", "Actual name and expected name do not match!");
        }
    }
}
