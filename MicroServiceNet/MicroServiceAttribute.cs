using System;
using System.Collections.Generic;
using System.Reflection;

namespace MicroServiceNet
{
    public class MicroServiceAttribute : Attribute
    {
        private readonly string _name;

        public MicroServiceAttribute(string name)
        {
            this._name = name;
        }



        public static string GetMicroService(Func<List<KeyValuePair<object, object>>, object> method)
        {
            var attrs = method.GetMethodInfo().GetCustomAttributes();

            foreach (var attr in attrs)
            {
                MicroServiceAttribute authAttr = attr as MicroServiceAttribute;
                if (authAttr != null)
                {
                    string auth = authAttr._name;

                    return auth;
                }
            }

            return null;
        }
    }
}