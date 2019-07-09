using Arcteryx.Pages;
using NUnit.Framework;
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
        public RemoteWebDriver Driver { get; private set; }
        public ItemsPage ItemsPg { get; private set; }
        public ItemPage ItemPg { get; private set; }
        private string _gridURL = ConfigurationManager.AppSettings["seleniumGridURL"];
        //http://localhost:4444/grid/console

        private AppManager()
        {
            //read data from nunit console
            string browserName = TestContext.Parameters["browserType"];  //string browserName = "chrome";  firefox or chrome  for manual running

            DesiredCapabilities capabilities = new DesiredCapabilities(); 
            capabilities.SetCapability(CapabilityType.BrowserName, browserName);

            Driver = new RemoteWebDriver(new Uri(_gridURL), capabilities);
            Driver.Manage().Window.Maximize();

            ItemsPg = new ItemsPage(this);
            ItemPg = new ItemPage(this);

            Logger.InitLogger();
        }


        public static AppManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AppManager();
            }
            return Instance;
        }
    }
}

