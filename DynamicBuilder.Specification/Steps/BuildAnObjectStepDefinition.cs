using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace DynamicBuilder.Specification.Steps
{
    [Binding]
    public class BuildAnObjectStepDefinition
    {
        private IBuilder Build = null;
        private Object AnObject = null;
        private Object AnotherObject = null;

        [Given(@"I have an instance of the DynamicBuilder named builder")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilderNamedBuilder()
        {
            Build = new Builder();
        }

        [When(@"I request the builder to build an instance of type System\.Object")]
        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypeSystem_Object()
        {
            AnObject = Build.An<Object>();
        }

        [When(@"I request the builder to build another instance of type System\.Object")]
        public void WhenIRequestTheBuilderToBuildAnotherInstanceOfTypeSystem_Object()
        {
            AnotherObject = Build.An<Object>();
        }

        [Then(@"I will receive from the builder an instance of type System\.Object")]
        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypeSystem_Object()
        {
            AnObject.Should().NotBeNull();
        }

        [Then(@"I will receive from the builder two different instances of type System\.Object")]
        public void ThenIWillReceiveFromTheBuilderTwoDifferentInstancesOfTypeSystem_Object()
        {
            AnObject.Should().NotBeNull();
            AnotherObject.Should().NotBeNull();
            AnObject.Should().NotBeSameAs(AnotherObject);
        }
    }
}
