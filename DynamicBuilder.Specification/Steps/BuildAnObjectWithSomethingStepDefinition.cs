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
    public class BuildAnObjectWithSomethingStepDefinition
    {
        private IBuilder<Person> APerson = null;
        private IBuilder<Report> AReport = null;
        private const string AReportTitle = "A Report Title";

        protected IBuilder Build = null;

        [Scope(Feature = "Build an object with something")]
        [Given(@"I have an instance of the DynamicBuilder")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilder()
        {
            Build = new Builder();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Report with Title")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReport = Build.A<Report>().WithTitle(AReportTitle);
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Person with FirstName")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Report with Date")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeReportWithDate()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Person with LastName")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithLastName()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will receive two different builders for two different instances of type Report with Title")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeReportWithTitle()
        {
            AReport.Should().NotBeNull();
            AReport.Value.Should().NotBeNull();
            AReport.Value.Title.Should().Be(AReportTitle);
        }

        [Then(@"I will receive two different builders for two different instances of type Person with FirstName")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypePersonWithFirstName()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will receive two different builders for two different instances of type Report with Date")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypeReportWithDate()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will receive two different builders for two different instances of type Person with LastName")]
        public void ThenIWillReceiveTwoDifferentBuildersForTwoDifferentInstancesOfTypePersonWithLastName()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
