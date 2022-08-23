Feature: Employee_Feature

A short summary of the feature

@mytag
Scenario Outline: Successful Login with valid credentials
    Given the Employee is on the login page
    When  the Employee inputs <email> as email
    And   the Employee inputs <password> as password
    And   the Employee clicks the Login button
    Then  the Employee should be redirected to their dashboard
 Examples:
 |email           |password|
 |anjali@gmail.com|    anju|


 Scenario: Successfully editing employee details
	Given Employee is on the EmployeeHomePage
	When the Employee clicks the Edit Button
	Then the Employee should be navigated to the Edit Page
	When the Employee enters <name> as Name
	And  the Employee enters <city> as City
	And  the Employee clicks on Update Button
	Then the Employee should be redirected to the EmployeeHomePage

 Examples:
 |name    |city|
 |Akruti  |Pune|

