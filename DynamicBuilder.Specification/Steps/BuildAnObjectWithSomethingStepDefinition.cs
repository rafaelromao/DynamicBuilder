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
        private IBuilder<Person> APersonWithFirstNameBuilder = null;
        private IBuilder<Person> APersonWithLastNameBuilder = null;
        private IBuilder<Report> AReportWithTitleBuilder = null;
        private IBuilder<Report> AReportWithDateBuilder = null;

        private readonly string AReportTitle = "Montly Report";
        private readonly DateTime AReportDate = new DateTime(2012, 10, 28);
        private readonly string APersonFirstName = "José";
        private readonly string APersonLastName = "da Silva";

        protected IBuilderFactory Factory = null;

        [Scope(Feature = "Build an object with something")]
        [Given(@"I have an instance of the BuilderFactory")]
        public void GivenIHaveAnInstanceOfTheBuilderFactory()
        {
            Factory = new BuilderFactory();
        }

        [Scope(Feature = "Build an object with something")]
        [When(@"I request the BuilderFactory to give me a builder for an instance of type Report with Title")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReportWithTitleBuilder = Factory.ABuilderFor<Report>().WithTitle(AReportTitle);
        }

        [Scope(Feature = "Build an object with something")]
        [When(@"I request the BuilderFactory to give me a builder for an instance of type Person with FirstName")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APersonWithFirstNameBuilder = Factory.ABuilderFor<Person>().WithFirstName(APersonFirstName);
        }

        [When(@"I request the BuilderFactory to give me a builder for an instance of type Report with Date")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypeReportWithDate()
        {
            AReportWithDateBuilder = Factory.ABuilderFor<Report>().WithDate(AReportDate);
        }

        [When(@"I request the BuilderFactory to give me a builder for an instance of type Person with LastName")]
        public void WhenIRequestTheBuilderFactoryToGiveMeABuilderForAnInstanceOfTypePersonWithLastName()
        {
            APersonWithLastNameBuilder = Factory.ABuilderFor<Person>().WithLastName(APersonLastName);
        }

        [Then(@"I will receive a builder for an instance of type Report with Title")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReportWithTitleBuilder.Should().NotBeNull();
            var aReportWithTitle = AReportWithTitleBuilder.Value;
            aReportWithTitle.Should().NotBeNull();
            aReportWithTitle.Title.Should().Be(AReportTitle);
        }

        [Then(@"I will receive a builder for an instance of type Person with FirstName")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APersonWithFirstNameBuilder.Should().NotBeNull();
            var aPersonWithFirstName = APersonWithFirstNameBuilder.Value;
            aPersonWithFirstName.Should().NotBeNull();
            aPersonWithFirstName.FirstName.Should().Be(APersonFirstName);
        }

        [Then(@"I will receive a builder for an instance of type Report with Date")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypeReportWithDate()
        {
            AReportWithDateBuilder.Should().NotBeNull();
            var aReportWithDate = AReportWithDateBuilder.Value;
            aReportWithDate.Should().NotBeNull();
            aReportWithDate.Date.Should().Be(AReportDate);
        }

        [Then(@"I will receive a builder for an instance of type Person with LastName")]
        public void ThenIWillReceiveABuilderForAnInstanceOfTypePersonWithLastName()
        {
            APersonWithLastNameBuilder.Should().NotBeNull();
            var aPersonWithLastName = APersonWithLastNameBuilder.Value;
            aPersonWithLastName.Should().NotBeNull();
            aPersonWithLastName.LastName.Should().Be(APersonLastName);
        }

    }
}
