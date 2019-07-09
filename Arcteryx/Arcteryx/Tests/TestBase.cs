using Arcteryx.Pages;
using Arcteryx.Utils;
using NUnit.Framework;
using System;

namespace Arcteryx.Tests
{
    /// <summary>
    /// Class with common functions for all test.
    /// </summary>
    
    public abstract class TestBase
    {
        protected AppManager Manager { get; set; }
        protected ItemsPage ItemsPg { get; set; }
        protected ItemPage ItemPg { get; set; }

        [OneTimeSetUp]
        public void BeforeTest()
        {
            Manager = AppManager.GetInstance();
            Manager.ItemPg.OpenPage("Main");
            ItemsPg = Manager.ItemsPg;
            ItemPg = Manager.ItemPg;
        }

        [TearDown]
        public void AfterTest()
        {
            string screenshotName;

            if (TestContext.CurrentContext.Result.Outcome.ToString() == "Failed")
            {
                screenshotName = TestContext.CurrentContext.Test.Name + " " + DateTime.Now.ToString("yyyy.MM.dd") +" "+ DateTime.Now.ToString("hh.mm.ss");
                ScreenCapture.TakeScreenshot(screenshotName);
            }           
        }
    }
}
