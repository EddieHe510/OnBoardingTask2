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
    public class ManageListings
    {
        public void ViewListings(IWebDriver driver)
        {
            ExtentReporting.LogInfo($"View Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            IWebElement manageListingsLink = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            manageListingsLink.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//i[@class=\"eye icon\"]", 5);
            // View the listing
            IWebElement eyeIcon = driver.FindElement(By.XPath("//i[@class=\"eye icon\"]"));
            eyeIcon.Click();
            Thread.Sleep(5000);
        }
        public void EditListing(IWebDriver driver)
        {
            ExtentReporting.LogInfo($"Edit Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            IWebElement manageListingsLink = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            manageListingsLink.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]", 5);
            // Edit the exsting listing
            IWebElement penIcon = driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[2]"));
            penIcon.Click();
            Thread.Sleep(3000);

            // Change Title
            IWebElement title = driver.FindElement(By.Name("title"));
            title.Clear();
            title.SendKeys("JAZZ CLUB");
            Thread.Sleep(3000);

            // Add new tags
            IWebElement tags = driver.FindElement(By.XPath("//input[@class=\"ReactTags__tagInputField\"]"));
            tags.SendKeys("Man's club");
            tags.SendKeys(Keys.Enter);
            Thread.Sleep(3000);

            // Identify the save button and click on it
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button\"]"));
            saveButton.Click();
            Thread.Sleep(3000);
        }

        public void DeleteListing(IWebDriver driver)
        {
            ExtentReporting.LogInfo($"Delete Listing");
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]", 5);
            // Click on Manage Listings Link
            IWebElement manageListingsLink = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/a[3]"));
            manageListingsLink.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//i[@class=\"remove icon\"]", 5);
            // Identify the delete button and click on it
            IWebElement deleteButton = driver.FindElement(By.XPath("//i[@class=\"remove icon\"]"));
            deleteButton.Click();
            Thread.Sleep(3000);

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 5);
            // Click on Yes
            IWebElement yesOption = driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
            yesOption.Click();
            Thread.Sleep(3000);

            // Check if the listing has been deleted
            IWebElement titleName = driver.FindElement(By.XPath("//td[@class=\"four wide\"]"));
            Assert.That(titleName.Text != "JAZZ CLUB", "The listing hasn't been deleted!");
            Thread.Sleep(3000);
        }


    }
}
