using OnboardingTest2.Utilites;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingTest2.Pages
{
    public class Profile
    {
        public void ProfileActions(IWebDriver driver)
        {
            // Availability
            // Click on Availability Time dropdown
            IWebElement availabilityIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            availabilityIcon.Click();

            // Click on Availability Time dropdown
            IWebElement availablilityDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
            availablilityDropdown.Click();
            // Click on Availability Time option (Select Part Time)
            IWebElement partTimeOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]"));
            partTimeOption.Click();

            //Click on Availability Hour dropdown
            IWebElement hoursIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            hoursIcon.Click();

            // Click on Availability Hour dropdown
            IWebElement hoursDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            hoursDropdown.Click();

            // Click on Availbility Hour dropdown (Select Less than 30hours a week)
            IWebElement hoursOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[2]"));
            hoursOption.Click();

            // Click on salary
            IWebElement salaryIcon = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            salaryIcon.Click();

            // Click on salary dropdown
            IWebElement salaryDropdown = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
            salaryDropdown.Click();

            // Click on salary dropdown (Select More than $1000 per month)
            IWebElement salaryOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]"));
            salaryOption.Click();


            // Description
            // Identify the Description write icon and click on it
            IWebElement descriptionIcon = driver.FindElement(By.XPath("//i[@class=\"outline write icon\"]"));
            descriptionIcon.Click();

            // Identify the Description textarea and input description
            IWebElement descriptionTextarea = driver.FindElement(By.XPath("//textarea[@name=\"value\"]"));
            descriptionTextarea.Click();
            descriptionTextarea.Clear();
            descriptionTextarea.SendKeys("I am Eddie, I am a Jazz music true lover!!!");

            // Identify the description save button and click on it
            IWebElement saveButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button"));
            saveButton.Click();

            // Languages
            // Identify the Languages Add New button and add language
            IWebElement languageAddNewButton = driver.FindElement(By.XPath("//div[@class=\"ui teal button \"]"));
            languageAddNewButton.Click();

            IWebElement addLanguageTextBox = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
            addLanguageTextBox.SendKeys("English");

            IWebElement languageDropDown = driver.FindElement(By.XPath("//select[@name=\"level\"]"));
            languageDropDown.Click();

            IWebElement fluentOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[2]/select/option[4]"));
            fluentOption.Click();

            IWebElement languageAddButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button\"]"));
            languageAddButton.Click();

            // Skills
            // Identify the Skills tag and click on it 
            IWebElement skillsTag = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]"));
            skillsTag.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//div[@class=\"ui teal button\"]", 5);
            // Identify the Skill add new button and add skill
            IWebElement skillAddNewButton = driver.FindElement(By.XPath("//div[@class=\"ui teal button\"]"));
            skillAddNewButton.Click();

            Thread.Sleep(3000);

            Wait.WaitToBeVisible(driver, "XPath", "//input[@name=\"name\"]", 5);
            IWebElement addSkillTextBox = driver.FindElement(By.XPath("//input[@name=\"name\"]"));
            addSkillTextBox.SendKeys("Dance");

            IWebElement skillDropDown = driver.FindElement(By.XPath("//select[@name=\"level\"]"));
            skillDropDown.Click();

            IWebElement expertOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[4]"));
            expertOption.Click();

            IWebElement skillSaveButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button \"]"));
            skillSaveButton.Click();

            // Education
            // Identify the Education tag and click on it
            IWebElement educationTag = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
            educationTag.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div", 5);
            // Identify the Education add new button and add education
            IWebElement educationAddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
            educationAddNewButton.Click();

            // college textbox
            IWebElement collegeTextBox = driver.FindElement(By.XPath("//input[@name=\"instituteName\"]"));
            collegeTextBox.SendKeys("USQ");

            // Country dropdown list
            IWebElement countryOfCollege = driver.FindElement(By.XPath("//select[@name=\"country\"]"));
            countryOfCollege.Click();

            IWebElement australiaOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[11]"));
            australiaOption.Click();

            // Title dropdown list
            IWebElement titleDropDown = driver.FindElement(By.XPath("//select[@name=\"title\"]"));
            titleDropDown.Click();

            IWebElement bAOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[3]"));
            bAOption.Click();

            // degree textbox
            IWebElement degreeTextbox = driver.FindElement(By.XPath("//input[@name=\"degree\"]"));
            degreeTextbox.SendKeys("Master");

            // Year of graduat
            IWebElement yearOfGraduat = driver.FindElement(By.XPath("//select[@name=\"yearOfGraduation\"]"));
            yearOfGraduat.Click();

            IWebElement secondOptiton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[3]"));
            secondOptiton.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//input[@class=\"ui teal button \"]", 5);
            // Click the add button
            IWebElement educationAddButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button \"]"));
            educationAddButton.Click();

            // Certifications
            // Identify the Certifications tag and click on it
            IWebElement certificationsTag = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            certificationsTag.Click();

            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div", 5);
            // Identify the certification add new button click on it and add certificate
            IWebElement certificationAddNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
            certificationAddNewButton.Click();

            IWebElement certificationTextBox = driver.FindElement(By.XPath("//input[@name=\"certificationName\"]"));
            certificationTextBox.SendKeys("Master of Jazz");

            IWebElement certifiedFromTextBox = driver.FindElement(By.XPath("//input[@name=\"certificationFrom\"]"));
            certifiedFromTextBox.SendKeys("Guess");

            IWebElement yearDropDown = driver.FindElement(By.XPath("//select[@class=\"ui fluid dropdown\"]"));
            yearDropDown.Click();

            IWebElement theFirstOption = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[2]"));
            theFirstOption.Click();

            // Click the add button
            IWebElement certificationAddButton = driver.FindElement(By.XPath("//input[@class=\"ui teal button \"]"));
            certificationAddButton.Click();
        }
    }
}
