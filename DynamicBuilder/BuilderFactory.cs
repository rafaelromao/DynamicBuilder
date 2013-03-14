using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public class BuilderFactory : IBuilderFactory
    {
        public dynamic ABuilderFor<T>() where T : new()
        {
            return new Builder<T>();
        }
    }
}
