Feature: Build an object
	In order to verify that the DynamicBuilder can build objects
	As a developer
	I want to receive, from an instance of DynamicBuilder, a new instance of a given type

@building
Scenario Outline: Build an object
	Given I have an instance of the DynamicBuilder
	When I request the DynamicBuilder to give me a builder for an instance of type <Type>
	Then I will receive a builder for an instance of type <Type>

	Examples:
		| Type          |
		| AnObject |
		| AThing |

@building
Scenario Outline: Build two objects
	Given I have an instance of the DynamicBuilder
	When I request the DynamicBuilder to give me a builder for an instance of type <Type>
	And I request the DynamicBuilder to give me a builder for another instance of type <Type>
	Then I will receive two different builders for two different instances of type <Type>

	Examples:
		| Type          |
		| AnObject |
		| AThing |