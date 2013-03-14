using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using DynamicBuilder.Specification.Model;

namespace DynamicBuilder.Specification.Steps
{
    [Binding]
    public class BuildTwoSlightlyDifferentObjectsUsingTheSameBuilderStepDefinition
    {
        private dynamic APersonBuilder = null;
        private Person FirstBuiltValue = null;
        private Person SecondBuiltValue = null;
        private string FirstBuiltValueFirstName = "José";
        private string SecondBuiltValueFirstName = "Pedro";

        protected IBuilderFactory Factory = null;

        [Scope(Feature = "Build two slightly different objects using the same builder")]
        [Given(@"I have an instance of the BuilderFactory")]
        public void GivenIHaveAnInstanceOfTheBuilderFactory()
        {
            Factory = new BuilderFactory();
        }

        [When(@"I request the BuilderFactory to give me a builder for an instance of type Person with FirstName of value José")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypePersonWithFirstNameOfValueJose()
        {
            APersonBuilder = Factory.ABuilderFor<Person>();
            APersonBuilder = APersonBuilder.WithFirstName(FirstBuiltValueFirstName);
        }
        
        [When(@"I request this first builder to give me the built value")]
        public void WhenIRequestThisFirstBuilderToGiveMeTheBuiltValue()
        {
            FirstBuiltValue = APersonBuilder.Value;
        }

        [When(@"I request this first builder to give me a new builder for an instance of type Person with FirstName of value Pedro")]
        public void WhenIRequestThisFirstBuilderToGiveMeANewBuilderForAnInstanceOfTypePersonWithFirstNameOfValuePedro()
        {
            APersonBuilder = APersonBuilder.WithFirstName(SecondBuiltValueFirstName);
        }

        [When(@"I request this second builder to give me the built value")]
        public void WhenIRequestThisSecondBuilderToGiveMeTheBuiltValue()
        {
            SecondBuiltValue = APersonBuilder.Value;
        }

        [Then(@"I will receive two different built values one matching José and the other matching Pedro")]
        public void ThenIWillReceiveTwoDifferentBuiltValuesOneMatchingJoseAndTheOtherMatchingPedro()
        {
            FirstBuiltValue.Should().NotBeNull();
            SecondBuiltValue.Should().NotBeNull();
            FirstBuiltValue.Should().NotBeSameAs(SecondBuiltValue);
            FirstBuiltValue.FirstName.Should().Be(FirstBuiltValueFirstName);
            SecondBuiltValue.FirstName.Should().Be(SecondBuiltValueFirstName);
        }
    }
}
