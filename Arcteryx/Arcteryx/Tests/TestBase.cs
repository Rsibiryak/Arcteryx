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
    [SetUpFixture]
    public abstract class TestBase
    {
        protected AppManager Manager { get; set; }
        protected MainPage MainPg { get; set; }
        protected ItemsPage ItemPg { get; set; }

        [OneTimeSetUp]
        public void BeforeTest()
        {
            Manager = AppManager.GetInstance();
            Manager.MainPg.OpenPage("Main");
            MainPg = Manager.MainPg;
            ItemPg = Manager.ItemsPg;
        }

        [OneTimeTearDown]
        public void AfterTest()
        {
            Manager.Driver.Quit();
        }
    }
}
