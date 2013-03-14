Feature: Build two slightly different objects using the same builder
	In order to verify that I can build two slightly different objects dynamically using the same builder
	As a developer
	I want to receive, from an instance of BuilderFactory, a builder that builds two different instances of a given type with the property values I set

@building
Scenario Outline: Build two slightly different objects using the same builder
	Given I have an instance of the BuilderFactory
	When I request the BuilderFactory to give me a builder for an instance of type <Type> with <Something> of value <A Value>
	And I request this first builder to give me the built value
	And I request this first builder to give me a new builder for an instance of type <Type> with <Something> of value <An Other Value>
	And I request this second builder to give me the built value
	Then I will receive two different built values one matching <A Value> and the other matching <An Other Value>

	Examples:
		| Type	 | Something | A Value | An Other Value	|
		| Person | FirstName | José    | Pedro	        |

