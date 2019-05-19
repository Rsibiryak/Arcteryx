using Arcteryx.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcteryx.Utils
{
    public class AppManager
    {
        public static AppManager Instance { get; private set; }
        public IWebDriver Driver { get; private set; }
        public ItemsPage ItemsPg { get; private set; }
        public ItemPage ItemPg { get; private set; }

        private AppManager()
        {
            Driver = new ChromeDriver();
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

