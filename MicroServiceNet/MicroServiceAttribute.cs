using System;
using System.Reflection;

namespace MicroServiceNet
{
    public class MicroServiceAttribute : Attribute
    {
        private string Name;

        public MicroServiceAttribute(string Name)
        {
            this.Name = Name;
        }



        public static string GetMicroService(Func<string> method)
        {
            var attrs = method.GetMethodInfo().GetCustomAttributes();

            foreach (object attr in attrs)
            {
                MicroServiceAttribute authAttr = attr as MicroServiceAttribute;
                if (authAttr != null)
                {
                    string auth = authAttr.Name;

                    return auth;
                }
            }

            return null;
        }
    }
}