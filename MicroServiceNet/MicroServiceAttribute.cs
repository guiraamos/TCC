using System;
using System.Collections.Generic;
using System.Reflection;

namespace MicroServiceNet
{
    public class MicroServiceAttribute : Attribute
    {
        private readonly string _name;
        private TypeRequest _action;

        public MicroServiceAttribute(string name, TypeRequest action)
        {
            this._name = name;
            this._action = action;
        }

        public static MicroService GetMicroService(MethodInfo methodInfo)
        {
            var attrs = methodInfo.GetCustomAttributes();

            foreach (var attr in attrs)
            {
                if (attr is MicroServiceAttribute authAttr)
                {
                    return new MicroService() { Name = authAttr._name, Action = authAttr._action };
                }
            }

            return null;
        }
    }
}