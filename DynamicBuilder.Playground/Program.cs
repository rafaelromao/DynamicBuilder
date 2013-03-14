using DynamicBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        class SomeClass
        {
            public string SomeProperty { get; set; }
            public DateTime SomeOtherProperty { get; set; }

            public override string ToString()
            {
                return SomeProperty + SomeOtherProperty.ToShortDateString();
            }
        }

        static void Main(string[] args)
        {
            var factory = new BuilderFactory();
            dynamic someClassBuilder = factory.ABuilderFor<SomeClass>();
            
            SomeClass someClass1 = someClassBuilder.WithSomeProperty("Today is ")
                                                   .WithSomeOtherProperty(DateTime.Today)
                                                   .Value;
            SomeClass someClass2 = someClassBuilder.WithSomeProperty("Yesterday was ")
                                                   .WithSomeOtherProperty(DateTime.Today.AddDays(-1))
                                                   .Value;
            Console.WriteLine(someClass1);
            Console.WriteLine(someClass2);
            Console.ReadKey();
        }
    }
}
