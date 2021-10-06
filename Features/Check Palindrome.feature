Feature: Check palindrome
	Check if palindrome functionality is working or not

@Sanity
Scenario: Check if given text is palindrome
	Given the user is on palindrome checker page
	When user enters the text <Text>
	And click on Check for palindromeness button
	Then <ResultMessage> message should be displayed

	Examples:
| Text   | ResultMessage |
| Sonos | It's a palindrome! |
| Sunil | Sorry, that's not a palindrome. |

