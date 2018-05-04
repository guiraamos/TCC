using System;

namespace MicroServiceNet
{
    public class MicroServiceHostAttribute : Attribute
    {
        private string Name;

        public MicroServiceHostAttribute(string Name)
        {
            this.Name = Name;
        }


        public static string GetMicroService(Func<string> method)
        {
            var a = method.Method.DeclaringType;

            foreach (var attr in a.CustomAttributes)
            {
                foreach (var item in attr.ConstructorArguments)
                {
                    return item.Value.ToString();
                }
            }

            return null;
        }
    }
}