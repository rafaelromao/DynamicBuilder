//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using TechTalk.SpecFlow;
//using FluentAssertions;
//using DynamicBuilder.Specification.Model;

//namespace DynamicBuilder.Specification.Steps
//{
//    [Binding]
//    public class BuildAnObjectWithSomethingStepDefinition
//    {
//        private Person APerson = null;
//        private Report AReport = null;

//        protected IBuilder Build = null;

//        [Given(@"I have an instance of the DynamicBuilder named builder")]
//        [Scope(Feature = "Build an object with something")]
//        public void GivenIHaveAnInstanceOfTheDynamicBuilderNamedBuilder()
//        {
//            Build = new Builder();
//        }

//        [When(@"I request the builder to build an instance of type Person with FirstName")]
//        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypePersonWithFirstName()
//        {
//            APerson = Build.A<Person>().WithFirstName("José da Silva");
//        }

//        [When(@"I request the builder to build an instance of type Report with Date")]
//        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypeReportWithDate()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [When(@"I request the builder to build an instance of type Person with LastName")]
//        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypePersonWithLastName()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [When(@"I request the builder to build an instance of type Report with Title")]
//        public void WhenIRequestTheBuilderToBuildAnInstanceOfTypeReportWithTitle()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [Then(@"I will receive from the builder an instance of type Person with FirstName")]
//        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypePersonWithFirstName()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [Then(@"I will receive from the builder an instance of type Report with Date")]
//        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypeReportWithDate()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [Then(@"I will receive from the builder an instance of type Person with LastName")]
//        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypePersonWithLastName()
//        {
//            ScenarioContext.Current.Pending();
//        }

//        [Then(@"I will receive from the builder an instance of type Report with Title")]
//        public void ThenIWillReceiveFromTheBuilderAnInstanceOfTypeReportWithTitle()
//        {
//            ScenarioContext.Current.Pending();
//        }

//    }
//}
