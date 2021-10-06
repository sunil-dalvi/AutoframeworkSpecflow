using AutoFrameworkWithSpecflow.Lib;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFrameworkWithSpecflow.PageObjects
{
    public class PalindromeCheckerPage : BasePage
    {
        By _TextArea = By.Name("textarea");
        By _PalindronCheckBtn = By.Id("palindrome-button");
        By _ResultLabel = By.Id("response");
        By _PopulateCheckerLink = By.XPath("//a[contains(.,'17,826 word palindrome')]");

        public PalindromeCheckerPage EnterTextToCheck(string text)
        {
            SetText(_TextArea, text);
            return this;
        }
        public PalindromeCheckerPage ClickPalindromCheckBtn()
        {
            Click(_PalindronCheckBtn);
            WaitHandler.WaitForTextToBePresent(_ResultLabel, "a");
            return this;
        }

        public string GetResultLabelText()
        {
            string result = GetText(_ResultLabel);
            return result;
        }

        public PalindromeCheckerPage PopulatePalindromeText()
        {
            Click(_PopulateCheckerLink);
            WaitHandler.WaitForSomeTextToBePresentInTextBox(_TextArea);
            return this;
        }
    }
}
