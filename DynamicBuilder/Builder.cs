using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DynamicBuilder
{
    public class Builder<T> : DynamicObject, IBuilder<T> where T : new()
    {
        protected Builder(T value)
        {
            Value = value;
        }

        public Builder()
            : this(new T())
        {
        }

        public T Value { get; private set; }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            var typeOfValue = typeof(T);
            try
            {
                var desiredPropertyName = GetDesiredPropertyNameFrom(binder.Name);
                if (desiredPropertyName == null)
                {
                    result = this;
                    return true;
                }
                var desiredPropertyOnValue = typeOfValue.GetProperty(desiredPropertyName);
                if (desiredPropertyOnValue == null)
                {
                    result = this;
                    return true;
                }
                var propertyValue = args[0];
                result = GetBuilderSettingPropertyOnValue(desiredPropertyOnValue, propertyValue);
                return true;
            }
            catch (Exception innerException)
            {
                throw BuildException(typeOfValue, binder.Name, innerException);
            }
        }

        private Exception BuildException(Type typeOfValue, string binderName, Exception innerException)
        {
            return new ArgumentException(String.Format("DynamicBuilder could not bind to any property on type {0} using binder {1}", typeOfValue.Name, binderName), innerException);
        }

        private IBuilder<T> GetBuilderSettingPropertyOnValue(PropertyInfo property, object propertyValue)
        {
            property.SetValue(this.Value, propertyValue);
            var builder = new Builder<T>(this.Value);
            return builder;
        }

        private string GetDesiredPropertyNameFrom(string dynamicMethodName)
        {
            var secondCapitalLetterIndex = GetSecondCapitalLetterIndexFrom(dynamicMethodName);
            if (IsValidIndexOnString(dynamicMethodName, secondCapitalLetterIndex))
            {
                var propertyName = dynamicMethodName.Substring(secondCapitalLetterIndex + 1, dynamicMethodName.Length - secondCapitalLetterIndex - 1);
                return propertyName;
            }
            return null;
        }

        private static bool IsValidIndexOnString(string dynamicMethodName, int firstCapitalLetterIndex)
        {
            return (firstCapitalLetterIndex > -1) && (firstCapitalLetterIndex < dynamicMethodName.Length);
        }

        private int GetSecondCapitalLetterIndexFrom(string dynamicMethodName)
        {
            dynamicMethodName = dynamicMethodName.Substring(1);
            var result = -1;
            var currentIndex = 0;
            foreach (var character in dynamicMethodName)
            {
                if (Char.IsLetter(character) && Char.IsUpper(character))
                {
                    result = currentIndex;
                    break;
                }
                currentIndex++;
            }
            return result;
        }
    }
}
