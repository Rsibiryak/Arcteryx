using Arcteryx.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Configuration;

namespace Arcteryx.Utils
{
    public class AppManager
    {
        public static AppManager Instance { get; private set; }
        public IWebDriver Driver { get; private set; }
        public ItemsPage ItemsPg { get; private set; }
        public ItemPage ItemPg { get; private set; }
        private string _gridURL = ConfigurationManager.AppSettings["seleniumGridURL"];
        //http://localhost:4444/grid/console

        private AppManager(String browserName)
        {
            //string browserName = "chrome";  //firefox

            DesiredCapabilities capabilities = new DesiredCapabilities(); 
            capabilities.SetCapability(CapabilityType.BrowserName, browserName);

            Driver = new RemoteWebDriver(new Uri(_gridURL), capabilities);
            Driver.Manage().Window.Maximize();

            ItemsPg = new ItemsPage(this);
            ItemPg = new ItemPage(this);
        }


        public static AppManager GetInstance(String browserName)
        {
            if (Instance == null)
            {
                Instance = new AppManager(browserName);
            }
            return Instance;
        }
    }
}

