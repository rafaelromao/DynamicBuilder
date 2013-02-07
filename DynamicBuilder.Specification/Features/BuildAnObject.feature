Feature: Build an object
	In order to verify that the DynamicBuilder can build objects
	As a developer
	I want to receive, from an instance of DynamicBuilder, a new instance of a given type

@building
Scenario Outline: Build an object
	Given I have an instance of the DynamicBuilder named builder
	When I request the builder to build an instance of type <Type>
	Then I will receive from the builder an instance of type <Type>

	Examples:
		| Type          |
		| System.Object |

@building
Scenario Outline: Build two objects
	Given I have an instance of the DynamicBuilder named builder
	When I request the builder to build an instance of type <Type>
	And I request the builder to build an instance of type <Type>
	Then I will receive from the builder two different instances of type <Type>

	Examples:
		| Type          |
		| System.Object |
