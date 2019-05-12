using Arcteryx.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Tests
{
    [TestFixture]
    class MainMenuTest : TestBase
    {
        [Test]
        public void CheckMainMenuMen()
        {           
            MainPg.MainMenuClick("Men");
            Assert.AreEqual("Men's", MainPg.GetLable("Men"));
        }

        [Test]
        public void CheckMainMenuWomen()
        {
            MainPg.MainMenuClick("Women");
            Assert.AreEqual("Women's", MainPg.GetLable("Women"));
        }

    }
}
