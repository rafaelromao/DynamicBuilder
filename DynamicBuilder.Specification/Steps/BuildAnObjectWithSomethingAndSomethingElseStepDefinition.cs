﻿using System;
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
        private dynamic APerson = null;
        private dynamic AReport = null;

        private readonly string AReportTitle = "Montly Report";
        private readonly DateTime AReportDate = new DateTime(2012, 10, 28);
        private readonly string APersonFirstName = "José";
        private readonly string APersonLastName = "da Silva";

        protected IBuilder Build = null;

        [Scope(Feature = "Build an object with something and something else")]
        [Given(@"I have an instance of the DynamicBuilder")]
        public void GivenIHaveAnInstanceOfTheDynamicBuilder()
        {
            Build = new Builder();
        }

        [Scope(Feature = "Build an object with something and something else")]
        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Person with FirstName")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypePersonWithFirstName()
        {
            APerson = Build.A<Person>().WithFirstName(APersonFirstName);
        }

        [Scope(Feature = "Build an object with something and something else")]
        [When(@"I request the DynamicBuilder to give me a builder for an instance of type Report with Title")]
        public void WhenIRequestTheDynamicBuilderToGiveMeABuilderForAnInstanceOfTypeReportWithTitle()
        {
            AReport = Build.A<Report>().WithTitle(AReportTitle);
        }

        [When(@"I request this builder to give me another builder for an instance of type Report with Date")]
        public void WhenIRequestThisBuilderToGiveMeAnotherBuilderForAnInstanceOfTypeReportWithDate()
        {
            APerson = APerson.WithLastName(APersonLastName);
        }

        [When(@"I request this builder to give me another builder for an instance of type Person with LastName")]
        public void WhenIRequestThisBuilderToGiveMeAnotherBuilderForAnInstanceOfTypePersonWithLastName()
        {
            AReport = AReport.WithDate(AReportDate);
        }

        [Then(@"I will receive a builder for a single instance of type Person with FirstName and LastName")]
        public void ThenIWillReceiveABuilderForASingleInstanceOfTypePersonWithFirstNameAndLastName()
        {
            APerson.Should().NotBeNull();
            APerson.Value.Should().NotBeNull();
            APerson.Value.FirstName.Should().Be(APersonFirstName);
            APerson.Value.LastName.Should().Be(APersonLastName);
        }

        [Then(@"I will receive a builder for a single instance of type Report with Title and Date")]
        public void ThenIWillReceiveABuilderForASingleInstanceOfTypeReportWithTitleAndDate()
        {
            AReport.Should().NotBeNull();
            AReport.Value.Should().NotBeNull();
            AReport.Value.Title.Should().Be(AReportTitle);
            AReport.Value.Date.Should().Be(AReportDate);
        }
    }
}