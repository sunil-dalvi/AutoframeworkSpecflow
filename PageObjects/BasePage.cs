using AutoFrameworkWithSpecflow.Lib;
using AutomationFramework.Lib;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AutoFrameworkWithSpecflow.PageObjects
{
    public abstract class BasePage
    {
        // Main Driver Object for the execution
        protected IWebDriver Driver;//= Browser.Get();

        protected BasePage()
        {            
            this.Driver = Browser.Get();
        }
        protected void Click(By by)
        {
            try
            {

                Find(by).Click();
            }
            catch (StaleElementReferenceException)
            {

                Find(by).Click();
            }
            catch (ElementClickInterceptedException)
            {
                WaitHandler.WaitForTimeToLapse(5);
                Find(by).Click();
            }
            catch (ElementNotInteractableException)
            {
                WaitHandler.WaitForTimeToLapse(5);

                Find(by).Click();
            }
            catch (Exception e)
            {
            throw e;
            }                       
        }

        protected IWebElement Find(By by, [Optional] int waittime)
        {
            IWebElement Elem;
            try
            {
                Elem = WaitHandler.WaitForElementToBePresent(by, waittime);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Elem;
        }
        protected string GetText(By by, [Optional] int waittime)
        {
            return Find(by, waittime).Text;
        }

        protected void SetText(By by, string value)
        {
            Find(by).Clear();
            Find(by).SendKeys(value);
        }
    }
}
