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
        public RemoteWebDriver Driver { get; private set; }
        public ItemsPage ItemsPg { get; private set; }
        public ItemPage ItemPg { get; private set; }
        private string _gridURL = ConfigurationManager.AppSettings["seleniumGridURL"];
        //http://localhost:4444/grid/console

        private AppManager()
        {
            string browserName = "chrome";  //firefox  chrome

           DesiredCapabilities capabilities = new DesiredCapabilities(); 
           capabilities.SetCapability(CapabilityType.BrowserName, browserName);


          //  var capabilities = new RemoteSessionSettings();
           // capabilities.AddMetadataSetting("browserName", browserName);
           // capabilities.AddMetadataSetting("platform", "Windows 10");
            //RemoteWebDriver driver = new RemoteWebDriver(new Uri("http://hub.crossbrowsertesting.com:80/wd/hub"), capabilities);


            Driver = new RemoteWebDriver(new Uri(_gridURL), capabilities);
            Driver.Manage().Window.Maximize();

            ItemsPg = new ItemsPage(this);
            ItemPg = new ItemPage(this);
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

