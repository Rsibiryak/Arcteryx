using Arcteryx.Pages;
using Arcteryx.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Pages
{
    /// <summary>
    /// Page with items list.
    /// </summary>
    public class ItemsPage : PageBase
    {
        /// <summary>
        /// Locators for web elements.
        /// </summary>
        #region
        protected const String MEN_LABLE = "//span[@itemprop= 'name' and contains(text(),'Men')]";
        protected const String WOMEN_LABLE = "//span[@itemprop= 'name' and contains(text(),'Women')]";
        protected const String EMPTY_CART_LABLE = "//h1[contains(text(), 'YOU CURRENTLY HAVE NO ITEMS IN YOUR SHOPPING CART.')]";
        protected const String BETA_SV_JACKET = "//span[contains(text(), 'Beta SV Jacket')]";
        protected const String SHELL_JACKET_LABLE = "//span[contains(text(),'Shell Jackets')]";
        #endregion

        public ItemsPage(AppManager appManager) : base(appManager)
        {
        }

        /// <summary>
        /// Get lable from page.
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        public String GetLable(String labelName)
        {
            String locator;

            switch (labelName)
            {
                case "Men":
                    locator = MEN_LABLE;
                    break;
                case "Women":
                    locator = WOMEN_LABLE;
                    break;
                case "Cart":
                    locator = EMPTY_CART_LABLE;
                    break;
                case "Shell Jackets":
                    locator = SHELL_JACKET_LABLE;
                    break;
                default:
                    throw new Exception("Incorrect label name");
            }

            return FindByXpath(locator).GetAttribute("textContent");
        }

        /// <summary>
        /// Select locator by input name;
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public String GetLocatorByName(String name)
        {
            String locator;

            if (name == "BETA_SV_JACKET")
            {
                locator = BETA_SV_JACKET;
            }
            else
            {
                locator = "";
            }
            return locator;
        }

        /// <summary>
        /// Scroll page to element.
        /// </summary>
        /// <param name="name"></param> Element name.
        /// <returns></returns>
        public ItemsPage ScrollToElement(String name)
        {
            String locator = GetLocatorByName(name);

            String js = "arguments[0].scrollIntoView(true);";
            ((IJavaScriptExecutor)Driver).ExecuteScript(js, FindByXpath(locator));

            return this;
        }

        /// <summary>
        /// Scroll to item and open it page.
        /// </summary>
        /// <param name="ItemName"></param>
        public void OpenItemPage(String ItemName)
        {
            String locator = GetLocatorByName(ItemName);

            ScrollToElement(ItemName);
            FindByXpath(locator).Click();
        }
    }
}
