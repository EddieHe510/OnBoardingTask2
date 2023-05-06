using OnboardingTest2.Utilites;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;
using ReportUtils.Reports;

namespace OnboardingTest2.Pages
{
    public class ShareSkill : CommonDriver
    {
        private IWebElement shareSkillButton => driver.FindElement(By.XPath("//a[@class=\"ui basic green button\"]"));
        private IWebElement titleTextBox => driver.FindElement(By.Name("title"));
        private IWebElement descriptionTextArea => driver.FindElement(By.Name("description"));
        private IWebElement categoryDropDown => driver.FindElement(By.Name("categoryId"));
        private IWebElement mOOption => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div/select/option[6]"));
        private IWebElement subcategoryDropDown => driver.FindElement(By.Name("subcategoryId"));
        private IWebElement vOOption => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[3]"));
        private IWebElement startDate => driver.FindElement(By.Name("startDate"));
        private IWebElement endDate => driver.FindElement(By.Name("endDate"));
        private IWebElement mondayOption => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
        private IWebElement startTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[2]/input"));
        private IWebElement endTime => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[3]/input"));         
        private IWebElement tagTextbox => driver.FindElement(By.XPath("//input[@class=\"ReactTags__tagInputField\"]"));
        private IWebElement skillExchangeTag => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        private IWebElement workSamples => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//input[@class=\"ui teal button\"]"));


        public void ShareSkillAction(string title, string description, string tagname, string startdate, string enddate, string starttime, string endtime, string sEtag)
        {
            ExtentReporting.LogInfo($"Write share skill form");

            // Identify the Share Skill button and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class=\"ui basic green button\"]", 5);
            shareSkillButton.Click();

            Wait.WaitToBeVisible(driver, "Name", "title", 5);
            // Identify the Title textbox and enter vaild title
            titleTextBox.SendKeys(title);

            // Identify the Description textarea and enter description
            descriptionTextArea.SendKeys(description);

            // Identify the Category dropdown list and select Music & Audio
            categoryDropDown.Click();
            mOOption.Click();

            // Identify the Category dropdown list and select the Subcategory
            subcategoryDropDown.Click();
            // Select the Voice over option
            vOOption.Click();

            // Identify the Tgas input a tag
            tagTextbox.SendKeys(tagname);
            tagTextbox.SendKeys(Keys.Enter);

            // Identify the Start date and End date then input value
            startDate.SendKeys(startdate);
            endDate.SendKeys(enddate);

            // Identify the Monday checkbox and click on it
            mondayOption.Click();

            // Identify the Monday start time box and end time box then input value
            startTime.SendKeys(starttime);
            endTime.SendKeys(endtime);

            // Identify the Skill-Exchange and input a tag
            skillExchangeTag.SendKeys(sEtag);
            skillExchangeTag.SendKeys(Keys.Enter);

            // Identify the Work Samples and click the plus button to upload photo
            workSamples.Click();

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send("G:\\OnboardingTest2\\OnBoardingTask2\\OnboardingTest2\\OnboardingTest2\\ExcelData\\123.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");

            // Identify the Save button and click on it
            saveButton.Click();
        }
    }
}
