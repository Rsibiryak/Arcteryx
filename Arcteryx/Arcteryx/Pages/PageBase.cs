using Arcteryx.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Pages
{
    public abstract class  PageBase
    {
        public IWebDriver Driver { get; private set;}
        public WebDriverWait Wait { get; set; }
        public String Url { get; private set;}

    private const int TIMEOUT = 7;
        
        #region
        protected const String MAIN_MENU_SECTION = "arcteryx-outdoor-header";
        protected const String MEN_MENU = "#men>a";
        protected const String WOMEN_MENU = "#women>a";
        protected const String CART_SECTION = "#header-host";
        protected const String CART = "#cartInfo";
        protected const String CART_ITEMS = "#cartItems";
        #endregion

        public PageBase(AppManager appManager)
        {
            this.Driver = appManager.Driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TIMEOUT));

            Url = ConfigurationManager.AppSettings["appUrl"];
        }

        /// <summary>
        /// Return element from shadow root.
        /// </summary>
        /// <param name="shadowRootSelector"></param> Element containing shadow dom
        /// <param name="elementSelector"></param> Desired item
        /// <returns></returns>
        public IWebElement ExpandRootElement(String shadowRootSelector, String elementSelector)
        {          
            String js = $"return document.querySelector('{shadowRootSelector}').shadowRoot.querySelector('{elementSelector}')";
            IWebElement element = (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript(js);
            return element;
        }

        /// <summary>
        /// Find element by xpath and explicit wait.
        /// </summary>
        /// <param name="xpath"></param>
        /// <returns></returns>
        public IWebElement FindByXpath(string xpath)
        {
            IWebElement element = Wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath(xpath));
            });
            return element;
        }

        /// <summary>
        /// Open page.
        /// </summary>
        /// <param name="pageName"></param>
        public void OpenPage(String pageName)
        {
            String page;

            switch (pageName)
            {
                case "Main":
                    page = Url;
                    break;
                case "MenShellJacket":
                    page = Url + ConfigurationManager.AppSettings["menShellJacket"];
                    break;
                case " ":
                    page = "";
                    break;
                default:
                    page = "";
                    break;
            }

            Driver.Navigate().GoToUrl(page);
        }

        public void MainMenuClick(String menuItem)
        {
            switch (menuItem)
            {
                case "Men":
                    ExpandRootElement(MAIN_MENU_SECTION, MEN_MENU).Click();
                    break;
                case "Women":
                    ExpandRootElement(MAIN_MENU_SECTION, WOMEN_MENU).Click();
                    break;
                case "Cart":
                    ExpandRootElement(CART_SECTION, CART).Click();
                    break;
                default:
                    break;
            }
        }

        public int GetCartItemsCount()
        {
            return Convert.ToInt32(ExpandRootElement(CART_SECTION, CART_ITEMS).GetAttribute("innerText"));
/*
            int itemsCount;
            try
            {
                itemsCount = Convert.ToInt32(ExpandRootElement(CART_SECTION, CART_ITEMS).GetAttribute("innerText"));
            }
            catch
            {
                itemsCount = 0;
            }
            return itemsCount;
            */
        }

        public Boolean CartIsEmpty()
        {
            return false;
        }
    }
}
