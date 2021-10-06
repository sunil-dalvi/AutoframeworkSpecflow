using AutomationFramework.Lib;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AutoFrameworkWithSpecflow.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver driver;
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        
        [BeforeScenario]
        public void BeforeScenario(ScenarioContext ScenarioContext)
        {
            string browserName = ConfigurationManager.AppSettings["Browser"];
            var env = ConfigurationManager.AppSettings["Environment"];
            Browser.Initialize(browserName);
            driver = Browser.Get();
            driver.Navigate().GoToUrl(env);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Quit();
        }
    }
}
