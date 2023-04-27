using ExcelDataReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Data;
using System.IO;

namespace ExcelReader
{
    [TestClass]
    public class ExcelTesting
    {
        static DataSet mTestData;

        [ClassInitialize]
        public static void BeforeAllTests(TestContext testContext)
        {
            using (var stream = File.Open(@"G:\OnboardingTest2\OnBoardingTask2\OnboardingTest2\OnboardingTest2\ExcelData\TestDataShareSkills.xlsx", FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    mTestData = reader.AsDataSet(
                        new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true,
                            }
                        }
                        );
                }
            }
        }


        [TestMethod]
        public void LaunchExcel()
        {
            WindowsDriver<WindowsElement> myDriver = null;
            AppiumOptions appOptions = new AppiumOptions();
            appOptions.AddAdditionalCapability("app", "WPS Office");
            appOptions.AddAdditionalCapability("appArguments", @"/e G:\\OnboardingTest2\\OnBoardingTask2\\OnboardingTest2\\OnboardingTest2\\ExcelData\\TestDataShareSkills.xlsx");

            myDriver = new WindowsDriver<WindowsElement>(
                new Uri("http://127.0.0.1:4723"),
                appOptions
                );
        }
    }
}
