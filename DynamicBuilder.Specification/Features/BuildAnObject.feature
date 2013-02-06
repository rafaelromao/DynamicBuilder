Feature: Build an object
	In order to verify that the DynamicBuilder can build an object
	As a developer
	I want to be build a System.Object

@building
Scenario: Build an object
	Given I have a DynamicBuilder instance
	When I invoke DynamicBuilder.A<System.Object>()
	Then I will receive a new instance System.Object

@building
Scenario: Build two objects
	Given I have a DynamicBuilder instance
	When I invoke DynamicBuilder.A<System.Object>()
	And I invoke DynamicBuilder.A<System.Object>()
	Then I will receive two different instance of System.Object
