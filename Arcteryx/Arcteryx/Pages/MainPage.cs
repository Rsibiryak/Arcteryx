using Arcteryx.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Pages
{
    public class MainPage : PageBase
    {
        #region
        private const String MEN_LABLE = "//span[@itemprop= 'name' and contains(text(),'Men')]";
        private const String WOMEN_LABLE = "//span[@itemprop= 'name' and contains(text(),'Women')]";
        private const String EMPTY_CART_LABLE = "//h1[contains(text(), 'YOU CURRENTLY HAVE NO ITEMS IN YOUR SHOPPING CART.')]";
        #endregion

        public MainPage(AppManager appManager) : base(appManager)
        {
        }

        /// <summary>
        /// Get lable from page
        /// </summary>
        /// <param name="menuType"></param>
        /// <returns></returns>
        public String GetLable(String menuType)
        {
            String locator;

            switch (menuType)
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
                default:
                    locator = "";
                    break;
            }

            return FindByXpath(locator).GetAttribute("textContent");            
        }
    }
}
