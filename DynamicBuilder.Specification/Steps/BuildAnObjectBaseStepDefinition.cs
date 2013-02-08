using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace DynamicBuilder.Specification.Steps
{
    [Binding]
    public class BuildAnObjectBaseStepDefinition
    {
        protected IBuilder Build = null;

        [Given(@"I have an instance of the DynamicBuilder named builder")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilderNamedBuilder()
        {
            Build = new Builder();
        }
    }
}
