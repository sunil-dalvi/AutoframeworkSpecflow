using AutomationFramework.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoFrameworkWithSpecflow.Lib
{
    public class WaitHandler
    {
        public static readonly double WaitTime = 30;

        /// <summary>
        /// Method used to to wait until the element is present in DOM.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElementToBePresent(By by, [Optional] double customWait)
        {
            try
            {
                double explicitWait = customWait == default(double) ? WaitTime : customWait;
                WebDriverWait Wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method used to to wait until the element is present in DOM.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitForElementToBePresentForReactUI(By by, [Optional] double customWait, IWebDriver driver)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(customWait));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method used to to wait until the all elements are present in DOM.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns>IWebElement</returns>
        public static ReadOnlyCollection<IWebElement> WaitForAllElementsToBePresent(By by, [Optional] double customWait)
        {
            try
            {
                double explicitWait = customWait == default(double) ? WaitTime : customWait;
                WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method used to to wait until the Invisibility Of Element.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns></returns>
        public static bool WaitForInvisibilityOfElement(By by, [Optional] double customWait)
        {
            double explicitWait = customWait == default(double) ? WaitTime : customWait;
            WebDriverWait Wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        /// <summary>
        /// Method used to to wait until the element is clickble
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns></returns>
        public static IWebElement WaitForElementToBeClickable(By by, [Optional] double customWait)
        {
            try
            {
                double explicitWait = customWait == default(double) ? WaitTime : customWait;
                WebDriverWait Wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method used to to wait until the element is clickble
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns></returns>
        public static bool WaitForElementToBeClickableReactUI(By by, [Optional] double customWait)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(customWait));
                Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Method used to to wait until the element is displayed.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns></returns>
        public static IWebElement WaitForElementToBeDisplayed(By by, [Optional] double customWait)
        {
            try
            {
                double explicitWait = customWait == default(double) ? WaitTime : customWait;
                WebDriverWait Wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Method used to wait until element is dissapeared
        /// </summary>
        /// <param name="by"></param>
        /// <param name="CustomWait"></param>
        /// <returns></returns>
        public static bool WaitForElementToDissapear(By by, [Optional] double CustomWait)
        {
            try
            {
                double ExplicitWait = CustomWait == default(double) ? WaitTime : CustomWait;
                WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(ExplicitWait));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (StaleElementReferenceException)
            {
                return true;
            }
            catch (NoSuchElementException)
            {
                return true;
            }
        }
        /// <summary>
        /// Method used to wait until element is staled
        /// </summary>
        /// <param name="element"></param>
        /// <param name="CustomWait"></param>
        /// <returns></returns>
        public static bool WaitForElementToStaleness(IWebElement element, [Optional] double CustomWait)
        {
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.StalenessOf(element));
        }

        /// <summary>
        /// Waits for text to be present in the web element. 
        /// </summary>
        /// <param name="element">the web element</param>
        /// <param name="expectedText">the expected text</param>
        public static bool WaitForTextToBePresent(By element, string expectedText, [Optional] double customWait)
        {
            double explicitWait = customWait == default(double) ? WaitTime : customWait;
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(explicitWait));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(element, expectedText));
        }

        /// <summary>
        /// Waits for some text to be present in the textbox element. 
        /// </summary>
        /// <param name="element">the web element</param>
        public static bool WaitForSomeTextToBePresentInTextBox(By by, [Optional] double customWait)
        {
            Func<IWebDriver, Boolean> condition = delegate (IWebDriver d)
            {
                string valueAttribute = d.FindElement(by).GetAttribute("value");
                return !string.IsNullOrEmpty(valueAttribute);
            };
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(condition);
        }
        /// <summary>
        /// This method will wait for specified time (seconds)
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static void WaitForTimeToLapse(int TimeInSeconds)
        {
            Thread.Sleep(TimeInSeconds * 1000);
        }
        /// <summary>
        /// Method to wait until certain value is present in the attribute of the element
        /// </summary>
        /// <param name="by"></param>
        /// <param name="attribute"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool WaitForAttributeToContainValue(By by, string attribute, string value)
        {
            Func<IWebDriver, Boolean> condition = delegate (IWebDriver d)
            {
                return d.FindElement(by).GetAttribute(attribute).Contains(value);
            };
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(condition);
        }
        /// <summary>
        /// Method used to wait until the checkbox is checked. PLease pass the svg' element as argument
        /// </summary>
        /// <param name="by"></param>
        /// <param name="CustomWait"></param>
        /// <returns></returns>
        public static bool WaitForElementToBeChecked(By by, [Optional] double CustomWait)
        {
            Func<IWebDriver, Boolean> condition = delegate (IWebDriver d)
            {
                string attribute = "";
                try
                {
                    IWebElement checkbox = d.FindElement(by);
                    IWebElement path = checkbox.FindElement(By.XPath(".//*[name()='path']"));
                    attribute = path.GetAttribute("d");
                }
                catch (Exception e)
                {

                }

                return attribute.Contains("M10,17L5,12L6.41,10.58L10,14.17L17.59,6.58L19,8M19,3H5C3.89");
            };
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(condition);
        }
        /// <summary>
        /// Method used to wait until checkbox is unchecked
        /// </summary>
        /// <param name="by"></param>
        /// <param name="CustomWait"></param>
        /// <returns></returns>
        public static bool WaitForElementToBeUnChecked(By by, [Optional] double CustomWait)
        {
            Func<IWebDriver, Boolean> condition = delegate (IWebDriver d)
            {
                string attribute = "";
                try
                {
                    IWebElement checkbox = d.FindElement(by);
                    IWebElement path = checkbox.FindElement(By.XPath(".//*[name()='path']"));
                    attribute = path.GetAttribute("d");
                }
                catch (Exception e)
                {

                }
                return !attribute.Contains("M10,17L5,12L6.41,10.58L10,14.17L17.59,6.58L19,8M19,3H5C3.89");
            };
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(condition);
        }
        
        public static bool ScrollTillElementIsLoaded(By by, [Optional] double CustomWait)
        {
            Func<IWebDriver, Boolean> condition = delegate (IWebDriver d)
            {
                ((IJavaScriptExecutor)Browser.Get()).ExecuteScript("scroll(0, 10)");
                return d.FindElements(by).Count > 0;
            };
            WebDriverWait wait = new WebDriverWait(Browser.Get(), TimeSpan.FromSeconds(WaitTime));
            return wait.Until(condition);
        }

        /// <summary>
        /// Method used to to wait until the element is displayed.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns></returns>
        public static IWebElement WaitForElementToBeDisplayedforReactUI(By by, [Optional] double customWait, IWebDriver driver)
        {
            try
            {
                WebDriverWait Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(customWait));
                return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method used to to wait until the all elements are present in DOM.
        /// </summary>
        /// <param name="by"></param>
        /// <param name="customWait"></param>
        /// <returns>IWebElement</returns>
        public static ReadOnlyCollection<IWebElement> WaitForAllElementsToBePresentForReactUI(By by, [Optional] double customWait, IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(customWait));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
