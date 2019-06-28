using NUnit.Framework;

namespace Arcteryx.Tests
{
    /// <summary>
    /// Check main menu buttons.
    /// </summary>
    [TestFixture]
    class MainMenuTest : TestBase
    {
        /// <summary>
        /// Check "man" menu.
        /// </summary>
        [Test]
        public void CheckMenuMen()
        {
            ItemsPg.MainMenuClick("Men");
            Assert.AreEqual("Men's", ItemsPg.GetLable("Men"));
        }

        /// <summary>
        /// Check "women" menu.
        /// </summary>
        [Test]
        public void CheckMenuWomen()
        {
            ItemsPg.MainMenuClick("Women");
            Assert.AreEqual("Women's", ItemsPg.GetLable("Women"));
        }

        /// <summary>
        /// Check "cart" menu.
        /// </summary>
        [Test]
        public void CheckMenuCart()
        {
            ItemsPg.MainMenuClick("Cart");
            if (ItemsPg.GetCartItemsCount() == 0 )
            {
                Assert.AreEqual("YOU CURRENTLY HAVE NO ITEMS IN YOUR SHOPPING CART.", ItemsPg.GetLable("Empty cart"));
            }
            else
            {
                Assert.AreEqual("Continue Checkout", ItemsPg.GetLable("Cart"));
            }           
        }
    }
}
