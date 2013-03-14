using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace DynamicBuilder.Specification.Steps
{
    using DynamicBuilder.Specification.Model;

    [Binding]
    public class BuildAnObjectStepDefinition
    {
        private IBuilder<AnObject> AnObjectBuilder = null;
        private IBuilder<AThing> AThingBuilder = null;
        private IBuilder<AnObject> AnotherObjectBuilder = null;
        private IBuilder<AThing> AnotherThingBuilder = null;

        protected IBuilderFactory Factory = null;

        [Given(@"I have an instance of the DynamicBuilder")]
        [Scope(Feature = "Build an object")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilder()
        {
            Factory = new BuilderFactory();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type AnObject")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeAnObject()
        {
            AnObjectBuilder = Factory.ABuilderFor<AnObject>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type AThing")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeAThing()
        {
            AThingBuilder = Factory.ABuilderFor<AThing>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for another instance of type AnObject")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnotherInstanceOfTypeAnObject()
        {
            AnotherObjectBuilder = Factory.ABuilderFor<AnObject>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for another instance of type AThing")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnotherInstanceOfTypeAThing()
        {
            AnotherThingBuilder = Factory.ABuilderFor<AThing>();
        }

        [Then(@"I will receive a builder for an instance of type AnObject")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeAnObject()
        {
            AnObjectBuilder.Should().NotBeNull();
            AnObjectBuilder.Should().BeAssignableTo<IBuilder<AnObject>>();
        }

        [Then(@"I will receive a builder for an instance of type AThing")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeAThing()
        {
            AThingBuilder.Should().NotBeNull();
            AThingBuilder.Should().BeAssignableTo<IBuilder<AThing>>();
        }

        [Then(@"I will receive two different builders for two different instances of type AnObject")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeAnObject()
        {
            ThenIWillReceiveABuilderForAnInstanceOfTypeAnObject();
            AnObjectBuilder.Should().NotBeSameAs(AnotherObjectBuilder);
            AnObjectBuilder.Value.Should().NotBeSameAs(AnotherObjectBuilder.Value);
        }

        [Then(@"I will receive two different builders for two different instances of type AThing")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeAThing()
        {
            ThenIWillReceiveABuilderForAnInstanceOfTypeAThing();
            AThingBuilder.Should().NotBeSameAs(AnotherThingBuilder);
            AThingBuilder.Value.Should().NotBeSameAs(AnotherThingBuilder.Value);
        }
    }
}
