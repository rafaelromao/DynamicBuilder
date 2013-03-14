Feature: Build an object with something
	In order to verify that I can build objects dynamically with some property set
	As a developer
	I want to receive, from an instance of BuilderFactory, a builder that builds an instance of a given type with the property value I set

@building
Scenario Outline: Build an object with something
	Given I have an instance of the BuilderFactory
	When I request the BuilderFactory to give me a builder for an instance of type <Type> with <Something>
	Then I will receive a builder for an instance of type <Type> with <Something>

	Examples:
		| Type	 | Something |
		| Person | FirstName |
		| Person | LastName |
		| Report | Title |
		| Report | Date |

