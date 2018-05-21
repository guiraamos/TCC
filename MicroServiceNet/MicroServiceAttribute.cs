using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Web.Mvc;

namespace MicroServiceNet
{
    public class MicroServiceAttribute : Attribute
    {
        private readonly string _name;
        private HttpVerbs _action;

        public MicroServiceAttribute(string name, HttpVerbs action)
        {
            this._name = name;
            this._action = action;
        }

        public static MicroService GetMicroService(Func<List<KeyValuePair<string, string>>, object> method)
        {
            var attrs = method.GetMethodInfo().GetCustomAttributes();

            foreach (var attr in attrs)
            {
                MicroServiceAttribute authAttr = attr as MicroServiceAttribute;
                if (authAttr != null)
                {
                    return new MicroService() { Name = authAttr._name, Action = authAttr._action };
                }
            }

            return null;
        }
    }
}