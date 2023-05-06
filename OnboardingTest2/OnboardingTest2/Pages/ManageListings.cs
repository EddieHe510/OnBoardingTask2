using NUnit.Framework;
using OnboardingTest2.Utilites;
using OpenQA.Selenium;
using ReportUtils.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingTest2.Pages
{
    public class ManageListings : CommonDriver
    {
        private IWebElement manageListingsLin => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
        private IWebElement eyeIcon => driver.FindElement(By.XPath("//i[@class=\"eye icon\"]"));
        private IWebElement penIcon => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]"));
        private IWebElement titleTextBox => driver.FindElement(By.Name("title"));
        private IWebElement descriptionTextArea => driver.FindElement(By.Name("description"));
        private IWebElement tagsTextBox => driver.FindElement(By.XPath("//input[@class=\"ReactTags__tagInputField\"]"));
        private IWebElement startDate => driver.FindElement(By.Name("startDate"));
        private IWebElement endDate => driver.FindElement(By.Name("endDate"));
        private IWebElement fridayOption => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[1]/div/input"));
        private IWebElement startTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[2]/input"));
        private IWebElement endTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[7]/div[3]/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//input[@class=\"ui teal button\"]"));
        private IWebElement deleteButton => driver.FindElement(By.XPath("//i[@class=\"remove icon\"]"));
        private IWebElement yesOption => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));




        public void ViewListings()
        {
            ExtentReporting.LogInfo($"View Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            manageListingsLin.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//i[@class=\"eye icon\"]", 5);
            // View the listing
            eyeIcon.Click();
            Thread.Sleep(5000);
        }
        public void EditListing(string title, string description, string tags, string startdate, string enddate, string starttime, string endtime)
        {
            ExtentReporting.LogInfo($"Edit Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            manageListingsLin.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]", 5);
            // Edit the exsting listing
            penIcon.Click();
            Thread.Sleep(3000);

            // Change Title
            titleTextBox.Clear();
            titleTextBox.SendKeys(title);
            Thread.Sleep(3000);

            // Identify the Description textarea and enter description
            descriptionTextArea.Clear();
            descriptionTextArea.SendKeys(description);

            // Add new tags
            tagsTextBox.SendKeys(tags);
            tagsTextBox.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            // Identify the Start date and End date then input value
            startDate.SendKeys(startdate);
            endDate.SendKeys(enddate);

            // Identify Firday option check box and clike on it
            fridayOption.Click();

            // Identify the Friday start time box and end time box then input value
            startTime.SendKeys(starttime);
            endTime.SendKeys(endtime);


            // Identify the save button and click on it
            saveButton.Click();
            Thread.Sleep(3000);
        }

        public void DeleteListing()
        {
            ExtentReporting.LogInfo($"Delete Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            manageListingsLin.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//i[@class=\"remove icon\"]", 5);
            // Identify the delete button and click on it
            deleteButton.Click();
            Thread.Sleep(3000);

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 5);
            // Click on Yes
            yesOption.Click();
            Thread.Sleep(3000);

            // Check if the listing has been deleted
            IWebElement titleName = driver.FindElement(By.XPath("//td[@class=\"four wide\"]"));
            Assert.That(titleName.Text != "JAZZ CLUB", "The listing hasn't been deleted!");
            Thread.Sleep(3000);
        }


    }
}
