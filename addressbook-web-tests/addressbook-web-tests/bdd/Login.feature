Feature: Login

Scenario: Login with valid credentials
	Given A user is logged out
	When I login with username "admin" and password "secret"
	Then I have logged in

Scenario: Login with invalid credentials
	Given A user is logged out
	When I login with username "user" and password "secret"
	Then I have not logged in