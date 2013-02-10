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
        private AnObject AnObject = null;
        private AThing AThing = null;
        private AnObject AnotherObject = null;
        private AThing AnotherThing = null;

        protected IBuilder Build = null;

        [Given(@"I have an instance of the DynamicBuilder named builder")]
        [Scope(Feature = "Build an object")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilderNamedBuilder()
        {
            Build = new Builder();
        }

        [When(@"I request the builder to build an instance of type AnObject")]
        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypeAnObject()
        {
            AnObject = Build.An<AnObject>();
        }

        [When(@"I request the builder to build an instance of type AThing")]
        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypeAThing()
        {
            AThing = Build.An<AThing>();
        }

        [When(@"I request the builder to build another instance of type AnObject")]
        public void WhenIRequestTheBuilderToBuildAnotherInstanceOfTypeAnObject()
        {
            AnotherObject = Build.An<AnObject>();
        }

        [When(@"I request the builder to build another instance of type AThing")]
        public void WhenIRequestTheBuilderToBuildAnotherInstanceOfTypeAThing()
        {
            AnotherThing = Build.An<AThing>();
        }

        [Then(@"I will receive from the builder an instance of type AnObject")]
        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypeAnObject()
        {
            AnObject.Should().NotBeNull();
        }

        [Then(@"I will receive from the builder an instance of type AThing")]
        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypeAThing()
        {
            AThing.Should().NotBeNull();
        }

        [Then(@"I will receive from the builder two different instances of type AnObject")]
        public void ThenIWillReceiveFromTheBuilderTwoDifferentInstancesOfTypeAnObject()
        {
            AnObject.Should().NotBeNull();
            AnotherObject.Should().NotBeNull();
            AnObject.Should().NotBeSameAs(AnotherObject);
        }

        [Then(@"I will receive from the builder two different instances of type AThing")]
        public void ThenIWillReceiveFromTheBuilderTwoDifferentInstancesOfTypeAThing()
        {
            AThing.Should().NotBeNull();
            AnotherThing.Should().NotBeNull();
            AThing.Should().NotBeSameAs(AnotherThing);
        }
    }
}
