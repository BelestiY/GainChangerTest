Feature: GainChangerTestTask

@GainChangerTest
Scenario: Signin to gainchanger website
Given I navigate to cozy fairy netlify
When I enter the login credentials
And I click login button
Then I would be redirected to gainchanger site
And I navigate to the resources menu
And I access the first blog in the list of blogs
And I extract the fields
And I quit the browser