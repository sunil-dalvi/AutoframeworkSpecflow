Feature: PopulateAndCheck
	Populate text and and chek for palindrome

@Sanity
Scenario: Populate palindrome text and check if it display correct message
	Given the user is on palindrome checker page
	When user populates the text
	And click on Check for palindromeness button
	Then It's a palindrome! message should be displayed

@Sanity
Scenario: Click on Check Palindrome without entering text
	Given the user is on palindrome checker page
	When click on Check for palindromeness button
	Then Enter some alpha-numeric characters. message should be displayed