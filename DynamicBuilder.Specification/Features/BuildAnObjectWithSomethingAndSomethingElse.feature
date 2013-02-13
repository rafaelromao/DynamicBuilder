Feature: Build an object with something and something else
	In order to verify that the DynamicBuilder can build objects with something and something else
	As a developer
	I want to receive, from an instance of DynamicBuilder, a new instance of a given type and pass it something and something else

@building
Scenario Outline: Build an object with something and something else
	Given I have an instance of the DynamicBuilder
	When I request the DynamicBuilder to give me a builder for an instance of type <Type> with <Something>
	And I request this builder to give me another builder for an instance of type <Type> with <Something Else>
	Then I will receive a builder for a single instance of type <Type> with <Something> and <Something Else>

	Examples:
		| Type	 | Something | Something Else |
		| Person | FirstName | LastName       |
		| Report | Title     | Date           |

