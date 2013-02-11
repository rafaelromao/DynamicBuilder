using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public interface IBuilder
    {
        dynamic An<T>() where T : new();
        dynamic A<T>() where T : new();
    }

    public interface IBuilder<T> : IBuilder where T : new()
    {
        T Value { get; }
    }
}
