using System;
using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Arcteryx.Utils
{
    public class ScreenCapture
    {
        private static IWebDriver _driver;
        private static string _screenPath;
     
        static ScreenCapture()
        {
            _driver = AppManager.GetInstance().Driver;
            _screenPath = ConfigurationManager.AppSettings["screenshotPath"];
        }

        public static void TakeScreenshot(string screenName)
        {
            string screenPath = _screenPath + screenName + ".jpg";

            try
            {
                ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(screenPath);
                TestContext.AddTestAttachment(screenPath, screenName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
