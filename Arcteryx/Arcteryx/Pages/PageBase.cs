using Arcteryx.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;

namespace Arcteryx.Pages
{
    /// <summary>
    /// Class with base functions for all pages.
    /// </summary>
    public abstract class  PageBase
    {
        public IWebDriver Driver { get; private set;}
        public WebDriverWait Wait { get; set; }
        public String Url { get; private set;}

        private const int TIMEOUT = 7;
        
        /// <summary>
        /// Locators for web elements.
        /// </summary>
        #region
        protected const String MAIN_MENU_SECTION = "arcteryx-outdoor-header";
        protected const String MEN_MENU = "#men>a";
        protected const String WOMEN_MENU = "#women>a";
        protected const String CART = "#cartInfo";
        protected const String CART_ITEMS = "#cartItems";
        protected const String POPUP_WINDOW = "'//h1[contains(text(), 'BE THE FIRST TO KNOW')]'";
        protected const String POPUP_WINDOW_CLOSE = "//div[@class = 'lity-close']";
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
        /// <param name="shadowRootSelector"></param> Element containing shadow dom.
        /// <param name="elementSelector"></param> Desired item.
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
                ClosePopupWindow();

                IWebElement element = Wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath(xpath));
                });

                return element;    
        }

        /// <summary>
        /// Open new page.
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
                default:
                    throw new Exception("Incorrect page name!");
            }

            Driver.Navigate().GoToUrl(page);
        }

        /// <summary>
        /// Click on main menu button.
        /// </summary>
        /// <param name="menuItem"></param>
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
                    ExpandRootElement(MAIN_MENU_SECTION, CART).Click();
                    break;
                default:
                    throw new Exception("Incorrect menu name");
            }
        }

        /// <summary>
        /// Get  quantity of item from the cart.
        /// </summary>
        /// <returns></returns>
        public int GetCartItemsCount()
        {
            int itemsCount;
            try
            {             
                itemsCount = Convert.ToInt32(ExpandRootElement(MAIN_MENU_SECTION, CART_ITEMS).GetAttribute("outerText"));
            }
            catch
            {
                itemsCount = 0;
            }
            return itemsCount;
        }

        /// <summary>
        /// Close popup window witch some time appear.
        /// </summary>
        public void ClosePopupWindow()
        {
            try
            {
                Driver.FindElement(By.XPath(POPUP_WINDOW));
                Driver.FindElement(By.XPath(POPUP_WINDOW_CLOSE)).Click();
            }
            catch 
            {
            }
        }
    }
}
