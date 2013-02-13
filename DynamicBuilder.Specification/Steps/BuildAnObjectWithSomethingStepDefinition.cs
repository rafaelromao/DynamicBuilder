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
        private IBuilder<Person> APersonWithFirstName = null;
        private IBuilder<Person> APersonWithLastName = null;
        private IBuilder<Report> AReportWithTitle = null;
        private IBuilder<Report> AReportWithDate = null;

        private readonly string AReportTitle = "Montly Report";
        private readonly DateTime AReportDate = new DateTime(2012, 10, 28);
        private readonly string APersonFirstName = "José";
        private readonly string APersonLastName = "da Silva";

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
            AReportWithTitle = Build.A<Report>().WithTitle(AReportTitle);
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Person with FirstName")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APersonWithFirstName = Build.A<Person>().WithFirstName(APersonFirstName);
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Report with Date")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeReportWithDate()
        {
            AReportWithDate = Build.A<Report>().WithDate(AReportDate);
        }

        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Person with LastName")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithLastName()
        {
            APersonWithLastName = Build.A<Person>().WithLastName(APersonLastName);
        }

        [Then(@"I will receive a builder for an instance of type Report with Title")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReportWithTitle.Should().NotBeNull();
            AReportWithTitle.Value.Should().NotBeNull();
            AReportWithTitle.Value.Title.Should().Be(AReportTitle);
        }

        [Then(@"I will receive a builder for an instance of type Person with FirstName")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APersonWithFirstName.Should().NotBeNull();
            APersonWithFirstName.Value.Should().NotBeNull();
            APersonWithFirstName.Value.FirstName.Should().Be(APersonFirstName);
        }

        [Then(@"I will receive a builder for an instance of type Report with Date")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeReportWithDate()
        {
            AReportWithDate.Should().NotBeNull();
            AReportWithDate.Value.Should().NotBeNull();
            AReportWithDate.Value.Date.Should().Be(AReportDate);
        }

        [Then(@"I will receive a builder for an instance of type Person with LastName")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypePersonWithLastName()
        {
            APersonWithLastName.Should().NotBeNull();
            APersonWithLastName.Value.Should().NotBeNull();
            APersonWithLastName.Value.LastName.Should().Be(APersonLastName);
        }

    }
}
