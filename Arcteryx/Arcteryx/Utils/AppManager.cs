using Arcteryx.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        public MainPage MainPg { get; private set; }


        private AppManager()
        {
            Driver = new ChromeDriver();
            MainPg = new MainPage(this);
        }


        public AppManager GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AppManager();
            }
            return this;
        }

    }
}





public IWebDriver Driver { get; private set; }
public LoginPage LoginPg { get; private set; }
public DashboardPage DashboardPg { get; private set; }


private ApplicationManager()
{
    Driver = new ChromeDriver();
    LoginPg = new LoginPage(this);
    DashboardPg = new DashboardPage(this);
}

public static ApplicationManager GetInstance()
{
    if (Instance == null)
    {
        Instance = new ApplicationManager();
    }
    return Instance;
}