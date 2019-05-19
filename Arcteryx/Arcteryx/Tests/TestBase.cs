using Arcteryx.Pages;
using Arcteryx.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Tests
{
    /// <summary>
    /// Class with common functions for all test.
    /// </summary>
    [SetUpFixture]
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

        [OneTimeTearDown]
        public void AfterTest()
        {
            Manager.Driver.Quit();
        }
    }
}
