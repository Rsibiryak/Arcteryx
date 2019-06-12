using Arcteryx.Pages;
using Arcteryx.Utils;
using NUnit.Framework;
using System.Collections.Generic;

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

        private static IEnumerable<TestCaseData> Browser
        {
            get
            {
                yield return new TestCaseData("chrome");
               /// yield return new TestCaseData("firefox");
            }
        }

     //   [OneTimeSetUp]
 
      //  [Test, TestCaseSource(nameof(Browser))]
        public void BeforeTest(string browserName)
        {
            Manager = AppManager.GetInstance(browserName);
            Manager.ItemPg.OpenPage("Main");
            ItemsPg = Manager.ItemsPg;
            ItemPg = Manager.ItemPg;
        }

       //[OneTimeTearDown]
        public void AfterTest()
        {
            Manager.Driver.Quit();
        }
    }
}
