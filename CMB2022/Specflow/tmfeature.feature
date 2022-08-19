Feature: Feature1

A short summary As a TurnUp portal admin
I would like to create, edit and delete time and material records
So that I can manage employees' time and materials successfully

@tag1
Scenario: Create time and material record with valid details
	Given I logged in to turn up portal successfully
	When I navigate to time and material page
	When I create a new time and materail record
	Then The record should be create successfully


	Scenario Outline: Edit time and material record with valid details
	Given I logged in to turn up portal successfully
	When I navigate to time and material page
	When I update '<Description>','<Code>' and '<Price>' on exsisting time and materail record
	Then The record should have the updated '<Description>','<Code>' and '<Price>'

	Examples:
	| Description  | Code     | Price |
	| Time         | Roshan   | 100   |
	| Material     | KEyboard | 200   |
	| EditedRecord | Mouse    | 300   |



	
	
			