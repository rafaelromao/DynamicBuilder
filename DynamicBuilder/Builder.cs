using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public class Builder : IBuilder
    {
        public T An<T>() where T : new()
        {
            return new T();
        }
    }
}
