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

        #endregion

        public MainPage(AppManager appManager) : base(appManager)
        {
        }

        public void MainMenuClick(String menuItem)
        {
            IWebElement shadowElement;

            switch (menuItem)
            {
                case "Men":
                    shadowElement = ExpandRootElement(MAIN_MENU_SECTION, MEN_MENU);
                    shadowElement.Click();
                    break;
                case "Women":
                    shadowElement = ExpandRootElement(MAIN_MENU_SECTION, WOMEN_MENU);
                    shadowElement.Click();
                    break;
                default:
                    break;
            }

        }

        public String GetLable(String menuType)
        {
            String locator;

            if (menuType == "Men")
            {
                locator = MEN_LABLE;
            }
            else
            {
                locator = WOMEN_LABLE;
            }
                
            return FindByXpath(locator).GetAttribute("textContent");
        }
    }
}
