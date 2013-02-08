Feature: Build an object with something
	In order to verify that the DynamicBuilder can build objects with something
	As a developer
	I want to receive, from an instance of DynamicBuilder, a new instance of a given type and pass it something

@building
Scenario Outline: Build an object with something
	Given I have an instance of the DynamicBuilder named builder
	When I request the builder to build an instance of type <Type> with <Something>
	Then I will receive from the builder an instance of type <Type> with <Something>

	Examples:
		| Type	 | Something |
		| Person | FirstName |
		| Person | LastName |
		| Report | Title |
		| Report | Date |

