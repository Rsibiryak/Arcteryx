using Arcteryx.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Pages
{
    public abstract class  PageBase
    {
        public IWebDriver Driver {get;}
        public PageBase(AppManager appManager) {
            this.Driver = appManager.Driver;
        }

        /// <summary>
        /// Return dom tree from shadow-root 
        /// </summary>
        /// <param name="domTree"></param>
        /// <returns></returns>
        public IWebElement expandRootElement(IWebElement domTree)
        {
            IWebElement element = (IWebElement)((IJavaScriptExecutor)Driver).ExecuteScript("return arguments[0].shadowRoot", domTree);
            return element;
        }
    }
}
