using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    class PropertySetterAction : IBuildAction
    {
        public PropertySetterAction(PropertyInfo property, object propertyValue)
        {
            Property = property;
            PropertyValue = propertyValue;
        }
        public PropertyInfo Property;
        public object PropertyValue;

        public void ExecuteOn(object target)
        {
            Property.SetValue(target, PropertyValue);
        }
    }
}
