Feature: Build an object
	In order to verify that I can build objects dynamically
	As a developer
	I want to receive, from an instance of BuilderFactory, a builder that builds an instance of a given type

@building
Scenario Outline: Build an object
	Given I have an instance of the BuilderFactory
	When I request the BuilderFactory to give me a builder for an instance of type <Type>
	Then I will receive a builder for an instance of type <Type>

	Examples:
		| Type          |
		| AnObject |
		| AThing |

@building
Scenario Outline: Build two objects
	Given I have an instance of the BuilderFactory
	When I request the BuilderFactory to give me a builder for an instance of type <Type>
	And I request the BuilderFactory to give me a builder for another instance of type <Type>
	Then I will receive two different builders for two different instances of type <Type>

	Examples:
		| Type          |
		| AnObject |
		| AThing |