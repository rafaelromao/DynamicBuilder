Feature: Build an object with something and something else
	In order to verify that I can build objects dynamically with some properties set
	As a developer
	I want to receive, from an instance of BuilderFactory, a builder that builds an instance of a given type with the property values I set

@building
Scenario Outline: Build an object with something and something else
	Given I have an instance of the BuilderFactory
	When I request the BuilderFactory to give me a builder for an instance of type <Type> with <Something>
	And I request this builder to give me a builder for an instance of type <Type> with <Something Else>
	Then I will receive a builder for a single instance of type <Type> with <Something> and <Something Else>

	Examples:
		| Type	 | Something | Something Else |
		| Person | FirstName | LastName       |
		| Report | Title     | Date           |

