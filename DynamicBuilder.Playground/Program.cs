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
        class HelloWorld
        {
            public string Message { get; set; }
            public DateTime Date { get; set; }

            public override string ToString()
            {
                return String.Format(Message, Date.ToShortDateString());
            }
        }

        static void Main(string[] args)
        {
            var factory = new BuilderFactory();
            dynamic helloWorldBuilder = factory.ABuilderFor<HelloWorld>();
            
            HelloWorld helloWorld1 = helloWorldBuilder.WithMessage("Today is {0}")
                                                      .WithDate(DateTime.Today)
                                                      .Value;
            HelloWorld helloWorld2 = helloWorldBuilder.WithMessage("Yesterday was {0}")
                                                      .WithDate(DateTime.Today.AddDays(-1))
                                                      .Value;
            Console.WriteLine(helloWorld1);
            Console.WriteLine(helloWorld2);
            Console.ReadKey();
        }
    }
}
