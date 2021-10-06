using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace AutomationFramework.Lib
{
   
    class Browser
    {
        public static ThreadLocal<IWebDriver> DriverStore = new ThreadLocal<IWebDriver>();

        public static IWebDriver Get()
        {
            return DriverStore.Value;
        }

        public static void Initialize(string browser)
        {
            string AppRoot = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string Driverpath = Path.Combine(AppRoot, @"");
            var downloadDirectory = Path.Combine(AppRoot, @"Downloads");

            IWebDriver Driver;
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("no-sandbox");
                    option.AddArgument("disable-infobars");
                    option.AddArgument("--noerrdialogs");
                    option.AddArgument("--ignore-certificate-errors");
                    option.AddArgument("--start-maximized");
                    option.AddExcludedArgument("enable-automation");
                    option.AddAdditionalCapability("useAutomationExtension", false);
                    option.AddArgument("--test-type");
                    option.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    option.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);

                    Driver = new ChromeDriver(Driverpath, option);
                    Driver.Manage().Window.Maximize();
                    break;

                case "Firefox":
                    Driver = new FirefoxDriver();
                    Console.WriteLine("Not Included, As Most of the application focusing on Chrome, Edge & IE ");
                    break;

                case "EdgeChrome":

                    Microsoft.Edge.SeleniumTools.EdgeOptions _option = new Microsoft.Edge.SeleniumTools.EdgeOptions();
                    var serv = Microsoft.Edge.SeleniumTools.EdgeDriverService.CreateChromiumService(Driverpath, "msedgedriver.exe");
                    _option.UseChromium = true;
                    _option.AddArgument("no-sandbox");
                    _option.AddArgument("disable-infobars");
                    _option.AddArgument("--noerrdialogs");
                    _option.AddArgument("--ignore-certificate-errors");
                    _option.AddArgument("--start-maximized");
                    _option.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                    _option.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    Driver = new Microsoft.Edge.SeleniumTools.EdgeDriver(serv, _option);
                    break;

                
                default:
                    //Default Load-out
                    ChromeOptions opt = new ChromeOptions();
                    opt.AddArgument("--disable-infobars");
                    opt.AddArgument("--noerrdialogs");
                    opt.AddArgument("--ignore-certificate-errors");
                    opt.AddArgument("--start-maximized");
                    opt.AddUserProfilePreference("download.default_directory", downloadDirectory);
                    Driver = new ChromeDriver(Driverpath, opt);
                    break;
            }
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(1);
            //Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            Driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(40);
            DriverStore.Value = Driver;
        }
    }
}
