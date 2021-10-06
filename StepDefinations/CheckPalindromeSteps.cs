using AutoFrameworkWithSpecflow.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
namespace AutoFrameworkWithSpecflow.StepDefinations
{
    [Binding]
    public class CheckPalindromeSteps
    {
        public PalindromeCheckerPage PalindromeCheckerPage;

        [Given(@"the user is on palindrome checker page")]
        public void GivenTheUserIsOnPalindromeCheckerPage()
        {
            PalindromeCheckerPage = new PalindromeCheckerPage();
        }
        
        [When(@"user enters the text (.*)")]
        public void WhenUserEntersTheText(string p0)
        {
            PalindromeCheckerPage.EnterTextToCheck(p0);
        }
        
        [When(@"click on Check for palindromeness button")]
        public void WhenClickOnCheckForPalindromenessButton()
        {
            PalindromeCheckerPage.ClickPalindromCheckBtn();
        }
        
        [When(@"user populates the text")]
        public void WhenUserPopulatesTheText()
        {
            PalindromeCheckerPage.PopulatePalindromeText();
        }
        
        [Then(@"(.*) message should be displayed")]
        public void ThenMessageShouldBeDisplayed(string p0)
        {
            string result = PalindromeCheckerPage.GetResultLabelText();
            Assert.That((result.Equals(p0)), Is.True);
        }
        
        
    }
}
