using Arcteryx.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
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
        private const int TIMEOUT = 7;

        #region
        protected const String MAIN_MENU_SECTION = "arcteryx-outdoor-header";
        protected const String MEN_MENU = "#men>a";
        protected const String WOMEN_MENU = "#women>a";
        #endregion

        public PageBase(AppManager appManager)
        {
            this.Driver = appManager.Driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TIMEOUT));
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

        public void OpenPage()
        {
            String page = "https://arcteryx.com/ca/en/";      
            Driver.Navigate().GoToUrl(page);
        }
    }
}
