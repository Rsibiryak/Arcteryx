using Arcteryx.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;

namespace Arcteryx.Utils
{
    public class AppManager
    {
        public static AppManager Instance { get; private set; }
        public IWebDriver Driver { get; private set; }
        public ItemsPage ItemsPg { get; private set; }
        public ItemPage ItemPg { get; private set; }
        private string _gridURL = "http://localhost:4444/grid/console";       //"http://localhost:4444/wd/hub";

        // private DesiredCapabilities _capabilities;

        private AppManager()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            string gridURL = "http://localhost:4444/wd/hub";
            Driver = new RemoteWebDriver(new Uri(gridURL), capabilities);

            /*
             *  ChromeOptions options = new ChromeOptions();
            _driver = new RemoteWebDriver(new Uri("http://localhost:4445/wd/hub"), options);
            _objectContainer.RegisterInstanceAs(_driver);
             */


            //Driver = new ChromeDriver();
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

