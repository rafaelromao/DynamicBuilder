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
        private IBuilder<AnObject> AnObject = null;
        private IBuilder<AThing> AThing = null;
        private IBuilder<AnObject> AnotherObject = null;
        private IBuilder<AThing> AnotherThing = null;

        protected IBuilder Build = null;

        [Given(@"I have an instance of the DynamicBuilder")]
        [Scope(Feature = "Build an object")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilder()
        {
            Build = new Builder();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type AnObject")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeAnObject()
        {
            AnObject = Build.An<AnObject>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type AThing")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeAThing()
        {
            AThing = Build.An<AThing>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for another instance of type AnObject")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnotherInstanceOfTypeAnObject()
        {
            AnotherObject = Build.An<AnObject>();
        }

        [When(@"I request the DynamicBuilder to give me a builder for another instance of type AThing")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnotherInstanceOfTypeAThing()
        {
            AnotherThing = Build.An<AThing>();
        }

        [Then(@"I will receive a builder for an instance of type AnObject")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeAnObject()
        {
            AnObject.Should().NotBeNull();
            AnObject.Should().BeAssignableTo<IBuilder<AnObject>>();
        }

        [Then(@"I will receive a builder for an instance of type AThing")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeAThing()
        {
            AThing.Should().NotBeNull();
            AThing.Should().BeAssignableTo<IBuilder<AThing>>();
        }

        [Then(@"I will receive two different builders for two different instances of type AnObject")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeAnObject()
        {
            ThenIWillReceiveABuilderForAnInstanceOfTypeAnObject();
            AnObject.Should().NotBeSameAs(AnotherObject);
            AnObject.Value.Should().NotBeSameAs(AnotherObject.Value);
        }

        [Then(@"I will receive two different builders for two different instances of type AThing")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeAThing()
        {
            ThenIWillReceiveABuilderForAnInstanceOfTypeAThing();
            AThing.Should().NotBeSameAs(AnotherThing);
            AThing.Value.Should().NotBeSameAs(AnotherThing.Value);
        }
    }
}
