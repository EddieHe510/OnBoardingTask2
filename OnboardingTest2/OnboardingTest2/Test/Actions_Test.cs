using NUnit.Framework;
using OnboardingTest2.Pages;
using OnboardingTest2.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnboardingTest2.Test
{
    [TestFixture]
    [Parallelizable]
    public class Actions_Test : CommonDriver
    {
        ShareSkill shareSkillObj = new ShareSkill();
        ManageListings mLObj = new ManageListings();

        [Test, Order(1)]
        public void ShareSkillForm()
        {
            shareSkillObj.ShareSkillAction(driver);
        }

        [Test, Order(2)]
        public void ViewAction()
        {
          mLObj.ViewListings(driver);
        }

        [Test, Order(3)]
        public void EditAction()
        {
          mLObj.EditListing(driver);
        }

        [Test, Order(4)]
        public void DeleteAction()
        {
          mLObj.DeleteListing(driver);
        }
        
    }
}
