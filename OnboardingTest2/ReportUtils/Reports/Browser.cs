using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportUtils.Reports
{
    public class Broswer
    {
        private IWebDriver driver;

        public Broswer(IWebDriver driver)
        { 
            this.driver = driver; 
        }

        public string GetScreenShot()
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;

            return img;
        }
    }
}
