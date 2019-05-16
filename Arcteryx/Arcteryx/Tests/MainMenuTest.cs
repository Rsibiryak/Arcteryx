using Arcteryx.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcteryx.Tests
{
    [TestFixture]
    class MainMenuTest : TestBase
    {
        [Test]
        public void CheckMenuMen()
        {
            MainPg.MainMenuClick("Men");
            Assert.AreEqual("Men's", MainPg.GetLable("Men"));
        }

        [Test]
        public void CheckMenuWomen()
        {
            MainPg.MainMenuClick("Women");
            Assert.AreEqual("Women's", MainPg.GetLable("Women"));
        }

        [Test]
        public void CheckMenuCart()
        {
            MainPg.MainMenuClick("Cart");
            Assert.AreEqual("YOU CURRENTLY HAVE NO ITEMS IN YOUR SHOPPING CART.", MainPg.GetLable("Cart"));
        }


    }
}
