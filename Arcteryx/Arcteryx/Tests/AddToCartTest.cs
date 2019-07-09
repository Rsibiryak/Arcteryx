using Arcteryx.Utils;
using NUnit.Framework;


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
            ItemPg.SelectColor(Enums.Colors.Red_Beach).SelectSize("S").AddToCartClick().CloseCartWindow();
            Assert.AreEqual(12, ItemPg.GetCartItemsCount());        
        }

    }
}
