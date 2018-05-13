using System;
using System.Collections.Generic;

namespace MicroServiceNet
{
    public class MicroServiceHostAttribute : Attribute
    {
        private readonly string _name;

        public MicroServiceHostAttribute(string name)
        {
            this._name = name;
        }


        public static string GetMicroService(Func<List<KeyValuePair<object, object>>, object> method)
        {
            var a = method.Method.DeclaringType;

            foreach (var attr in a.CustomAttributes)
            {
                if (attr.AttributeType.Name.Equals("MicroServiceHostAttribute"))
                {
                    foreach (var item in attr.ConstructorArguments)
                    {
                        return item.Value.ToString();
                    }
                }
            }

            return null;
        }
    }
}