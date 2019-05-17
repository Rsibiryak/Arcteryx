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
    class ItemsPage : PageBase
    {
        #region
        public const String BETA_SV_JACKET = "//span[contains(text(), 'Beta SV Jacket')]";
        #endregion

        public ItemsPage(AppManager appManager) : base(appManager)
        {
        }


        public void ScrollToElement(String element)
        {
            String locator;

            if (element == "BETA_SV_JACKET")
            {
                locator = BETA_SV_JACKET;
            }
            else
            {
                locator = "";
            }
            String js = "arguments[0].scrollIntoView(true);";
            ((IJavaScriptExecutor)Driver).ExecuteScript(js, FindByXpath(locator));
        }
    }
}
