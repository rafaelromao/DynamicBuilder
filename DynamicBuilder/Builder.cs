using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public class Builder : IBuilder
    {
        public dynamic An<T>() where T : new()
        {
            return new Builder<T>();
        }
        public dynamic A<T>() where T : new()
        {
            return An<T>();
        }
    }

    public class Builder<T> : Builder, IBuilder<T>
    {
        public T Value { get; private set; }
    }
}
