﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcteryx.Tests
{
    /// <summary>
    /// Add to cart and check item quantity in the cart. 
    /// </summary>
    [TestFixture]
    class AddToCartTest : TestBase
    {
        /// <summary>
        /// Open soft shell jacket page.
        /// </summary>
        [SetUp]
        public void OpenItemPage()
        {
            ItemsPg.OpenPage("MenShellJacket");
            Assert.AreEqual("Shell Jackets", ItemsPg.GetLable("Shell Jackets"));
            ItemsPg.OpenItemPage("BETA_SV_JACKET");                
        }

        /// <summary>
        /// Add jacket to cart.
        /// </summary>
        [Test]
        public void AddCartTest()
        {
            ItemPg.SelectSize("S").AddToCartClick().CloseCartWindow();
            Assert.AreEqual(1, ItemPg.GetCartItemsCount());
        }
    }
}
