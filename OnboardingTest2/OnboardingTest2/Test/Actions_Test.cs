using NUnit.Framework;
using OnboardingTest2.Pages;
using OnboardingTest2.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ReportUtils.Reports;
using System.Net.Mail;
using CompetitionTask.Utilites;

namespace OnboardingTest2.Test
{
    [TestFixture]
    [Parallelizable]
    public class Actions_Test : CommonDriver
    {
        ShareSkill shareSkillObj = new ShareSkill();
        ManageListings mLObj = new ManageListings();

        [Test, Order(1)]
        public void SignIn()
        {
            ExcelLib.PopulateInCollection(@"G:\CompetitionTaskData\TestData.xlsx", "SignIn");
            SignIn signIn = new SignIn();
            // signIn.SignInActions(ExcelLib.ReadData(1, "Emailaddress"), ExcelLib.ReadData(1, "Password"));
            signIn.SignInActions(ExcelLib.ReadData(2, "Emailaddress"), ExcelLib.ReadData(2, "Password"));
        }


        [Test, Order(2)]
        public void ShareSkillForm()
        {           
            ExtentReporting.LogInfo("Share Skills Action");
            shareSkillObj.ShareSkillAction(driver);
        }

        [Test, Order(3)]
        public void ViewAction()
        {
            ExtentReporting.LogInfo("View listings Action");
            mLObj.ViewListings(driver);
        }

        [Test, Order(4)]
        public void EditAction()
        {
            ExtentReporting.LogInfo("Edit Listing Action");
            mLObj.EditListing(driver);
        }

        [Test, Order(5)]
        public void DeleteAction()
        {
            ExtentReporting.LogInfo("Delete Listing Action");
            mLObj.DeleteListing(driver);
        }
    }
}
