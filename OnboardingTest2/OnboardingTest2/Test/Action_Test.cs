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
using System.IO;
using System.IO.Enumeration;

namespace CompetitionTask.Test
{
    [TestFixture]
    [Parallelizable]
    public class ShareSkills_Test : CommonDriver
    {
        SignIn signIn = new SignIn();
        ShareSkill shareSkillObj = new ShareSkill();
        ManageListings mL = new ManageListings();

        [Test, Order(1)]
        public void ShareSkillForm()
        {           
            ExtentReporting.LogInfo("Share Skills Action");
            ExcelLib.ClearData();

            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestData.xlsx", "Login");
            signIn.SignInActions(ExcelLib.ReadData(1, "Emailaddress"), ExcelLib.ReadData(1, "Password"));

            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestDataShareSkills.xlsx", "ShareSkill");
            shareSkillObj.ShareSkillAction(ExcelLib.ReadData(1, "Title"), ExcelLib.ReadData(1, "Description"), ExcelLib.ReadData(1, "Tag"), 
                                           ExcelLib.ReadData(1, "Startdate"),ExcelLib.ReadData(1, "Enddate"),ExcelLib.ReadData(1, "Starttime"),ExcelLib.ReadData(1, "Endtime"),ExcelLib.ReadData(1, "SKTag"));
        }

        [Test, Order(2)]
        public void ViewAction()
        {
            ExtentReporting.LogInfo("View listings Action");
            ExcelLib.ClearData();

            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestData.xlsx", "Login");
            signIn.SignInActions(ExcelLib.ReadData(1, "Emailaddress"), ExcelLib.ReadData(1, "Password"));

            mL.ViewListings();
        }

        [Test, Order(3)]
        public void EditAction()
        {
            ExtentReporting.LogInfo("Edit Listing Action");

            ExcelLib.ClearData();

            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestData.xlsx", "Login");
            signIn.SignInActions(ExcelLib.ReadData(1, "Emailaddress"), ExcelLib.ReadData(1, "Password"));

            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestDataManageListings.xlsx", "ManageListings");
            mL.EditListing(ExcelLib.ReadData(1, "Title"), ExcelLib.ReadData(1, "Description"), ExcelLib.ReadData(1, "Tags"),
                              ExcelLib.ReadData(1, "Startdate"), ExcelLib.ReadData(1, "Enddate"), ExcelLib.ReadData(1, "Starttime"), ExcelLib.ReadData(1, "Endtime"));
        }

        [Test, Order(4)]
        public void DeleteAction()
        {
            ExtentReporting.LogInfo("Delete Listing Action");

            ExcelLib.ClearData();
            ExcelLib.PopulateInCollection(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestData.xlsx", "Login");
            signIn.SignInActions(ExcelLib.ReadData(1, "Emailaddress"), ExcelLib.ReadData(1, "Password"));

            mL.DeleteListing();
        }
    }
}
