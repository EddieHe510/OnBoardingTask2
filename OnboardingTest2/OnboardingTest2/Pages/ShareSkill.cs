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
    public class ShareSkill
    {
        public void ShareSkillAction(IWebDriver driver)
        {
            ExtentReporting.LogInfo($"Write share skill form");

            // Identify the Share Skill button and click on it
            Wait.WaitToBeClickable(driver, "XPath", "//a[@class=\"ui basic green button\"]", 5);
            IWebElement shareSkillButton = driver.FindElement(By.XPath("//a[@class=\"ui basic green button\"]"));
            shareSkillButton.Click();

            Wait.WaitToBeVisible(driver, "Name", "title", 5);
            // Identify the Title textbox and enter vaild title
            IWebElement titleTextBox = driver.FindElement(By.Name("title"));
            titleTextBox.SendKeys("Jazz Club");

            // Identify the Description textarea and enter description
            IWebElement descriptionTextArea = driver.FindElement(By.Name("description"));
            descriptionTextArea.SendKeys("We are true Jazz lover, If you are intrested in Jazz please feel free to join us!!");

            // Identify the Category dropdown list and select Music & Audio
            IWebElement categoryDropDown = driver.FindElement(By.Name("categoryId"));
            categoryDropDown.Click();

            IWebElement mOOption = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div/select/option[6]"));
            mOOption.Click();

            // Identify the Category dropdown list and select the Subcategory
            IWebElement subcategoryDropDown = driver.FindElement(By.Name("subcategoryId"));
            subcategoryDropDown.Click();
            // Select the Voice over option
            IWebElement vOOption = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[3]"));
            vOOption.Click();

            // Identify the Tgas input a tag
            IWebElement tagTextbox = driver.FindElement(By.XPath("//input[@class=\"ReactTags__tagInputField\"]"));
            tagTextbox.SendKeys("JAZZ");
            tagTextbox.SendKeys(Keys.Enter);

            // Identify the Skill-Exchange and input a tag
            IWebElement skillExchangeTag = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
            skillExchangeTag.SendKeys("Photo Skill");
            skillExchangeTag.SendKeys(Keys.Enter);

            // Identify the Work Samples and click the plus button to upload photo
            IWebElement workSamples = driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i"));
            workSamples.Click();

            AutoItX3 autoIt = new AutoItX3();
            autoIt.WinActivate("Open");
            Thread.Sleep(2000);
            autoIt.Send("C:\\Users\\EddieHe\\Desktop\\123.jpg");
            Thread.Sleep(1000);
            autoIt.Send("{ENTER}");


            // Identify the Save button and click on it
            IWebElement saveButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button\"]"));
            saveButton.Click();
        }
    }
}
