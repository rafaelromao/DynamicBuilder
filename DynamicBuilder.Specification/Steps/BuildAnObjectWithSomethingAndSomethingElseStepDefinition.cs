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
    public class BuildAnObjectWithSomethingAndSomethingElseStepDefinition
    {
        private dynamic APersonBuilder = null;
        private dynamic AReportBuilder = null;

        private readonly string AReportTitle = "Montly Report";
        private readonly DateTime AReportDate = new DateTime(2012, 10, 28);
        private readonly string APersonFirstName = "José";
        private readonly string APersonLastName = "da Silva";

        protected IBuilderFactory Factory = null;

        [Scope(Feature = "Build an object with something and something else")]
        [Given(@"I have an instance of the BuilderFactory")]
        public void GivenIHaveAnInstanceOfTheBuilderFactory()
        {
            Factory = new BuilderFactory();
        }

        [Scope(Feature = "Build an object with something and something else")]
        [When(@"I request the BuilderFactory to give me a builder for an instance of type Person with FirstName")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APersonBuilder = Factory.ABuilderFor<Person>().WithFirstName(APersonFirstName);
        }

        [Scope(Feature = "Build an object with something and something else")]
        [When(@"I request the BuilderFactory to give me a builder for an instance of type Report with Title")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReportBuilder = Factory.ABuilderFor<Report>().WithTitle(AReportTitle);
        }

        [When(@"I request this builder to give me a builder for an instance of type Report with Date")]
        public void WhenIRequestThisBuilderToGiveMeABuilderForAnInstanceOfTypeReportWithDate()
        {
            APersonBuilder = APersonBuilder.WithLastName(APersonLastName);
        }

        [When(@"I request this builder to give me a builder for an instance of type Person with LastName")]
        public void WhenIRequestThisBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithLastName()
        {
            AReportBuilder = AReportBuilder.WithDate(AReportDate);
        }

        [Then(@"I will receive a builder for a single instance of type Person with FirstName and LastName")]
        public void ThenIWillReceiveABuilderForASingleInstanceOfTypePersonWithFirstNameAndLastName()
        {
            APersonBuilder.Should().NotBeNull();
            Person aPerson = APersonBuilder.Value;
            aPerson.Should().NotBeNull();
            aPerson.FirstName.Should().Be(APersonFirstName);
            aPerson.LastName.Should().Be(APersonLastName);
        }

        [Then(@"I will receive a builder for a single instance of type Report with Title and Date")]
        public void ThenIWillReceiveABuilderForASingleInstanceOfTypeReportWithTitleAndDate()
        {
            AReportBuilder.Should().NotBeNull();
            Report aReport = AReportBuilder.Value;
            aReport.Should().NotBeNull();
            aReport.Title.Should().Be(AReportTitle);
            aReport.Date.Should().Be(AReportDate);
        }
    }
}
