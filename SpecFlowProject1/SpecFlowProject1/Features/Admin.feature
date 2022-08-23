Feature: Admin_Feature

A short summary of the feature

@mytag
Scenario Outline: Successful Login with valid credentials
    Given the Admin is on the login page
    When  the Admin inputs <email> as email
    And   the Admin inputs <password> as password
    And   the Admin clicks the Login button
    Then  the Admin should be redirected to their dashboard
 Examples:
 |email      |password|
 |a@gmail.com|      p1|


 Scenario: Successfully creating new Department
	Given Admin is on the Admin Home Page
	When the Admin clicks the Add New Department button
	Then the Admin is navigated to AddNewDepartment Page
	When the Admin inputs <departmentName> as DepartmentName
	And the Admin clicks on AddNewDepartment Button
	Then the Admin should be redirected to the AdminHomePage
	Examples:
   |departmentName     |
   |    SALES    |

Scenario: Successfully creating new Employee
	Given The Admin is on the Admin Home Page
	When the Admin clicks the AddNewEmployee button
	Then the Admin is navigated to Create Page
	When the Admin enters <email> as email
	And the Admin  enters <password> as password
	And the Admin inputs <name> as name
	And the Admin inputs <role> as role
	And the Admin selects department Id
	And the Admin inputs joining date
	And the Admin inputs <address> as address
	And the Admin inputs <city> as city
	And the Admin inputs <phoneNumber> as phoneNumber
	And the Admin inputs <state> as state
	And the Admin inputs <zipcode> as zipcode
	And the Admin inputs <country> as country
	And the Admin clicks on Create Button
	
	Examples:
 |email           |password|name    |role    |address     |city  |phoneNumber|state      |zipcode|country|
 |anjali@gmail.com|    anju|Anuradha|EMPLOYEE|Basant Nagar|Gondia|12233434   |Maharashtra|441614 |India  |

 Scenario: Successfully editing employee details
	Given User is on the AdminHomePage
	When the Admin clicks the Edit Button
	Then the Admin should be navigated to the Edit Page
	When the Admin enters Akruti as Name
	And  the Admin enters Pune as City
	And  the Admin clicks on Update Button

	Scenario: Successfully Deleting an Employee
	Given Admin is on the Admin_HomePage
	When the Admin clicks on the Delete Button
	Then the Admin is navigated to Delete Page
	When the Admin clicks the Delete Button

