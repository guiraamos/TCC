using RestSharp;
using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace MicroServiceNet
{
    public class MyClassBuilder
    {
        AssemblyName asemblyName;
        public MyClassBuilder(string ClassName)
        {
            this.asemblyName = new AssemblyName(ClassName);
        }

        public object CreateObject(string[] PropertyNames, Type[] Types)
        {

            TypeBuilder DynamicClass = this.CreateClass();
            this.CreateConstructor(DynamicClass);
            for (int ind = 0; ind < PropertyNames.Count(); ind++)
            {
                var mthdName = "";
                var param = "Execute<ProductService>(AddProduct, Method.POST, parameters);";



                CreateMethod(DynamicClass, mthdName, param, typeof(IRestResponse), "A");
            }

            Type type = DynamicClass.CreateType();

            return Activator.CreateInstance(type);
        }

        private TypeBuilder CreateClass()
        {
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName
                                , TypeAttributes.Public |
                                TypeAttributes.Class |
                                TypeAttributes.AutoClass |
                                TypeAttributes.AnsiClass |
                                TypeAttributes.BeforeFieldInit |
                                TypeAttributes.AutoLayout
                                , null);
            return typeBuilder;
        }

        private void CreateConstructor(TypeBuilder typeBuilder)
        {
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
        }

        private void CreateMethod(TypeBuilder myTypeBld, string mthdName, Type[] mthdParams, Type returnType, string mthdAction)
        {
            MethodBuilder myMthdBld = myTypeBld.DefineMethod(mthdName, MethodAttributes.Public | MethodAttributes.Static, returnType, mthdParams);
            ILGenerator ILout = myMthdBld.GetILGenerator();
            int numParams = mthdParams.Length;
            for (byte x = 0; x < numParams; x++)
            {
                ILout.Emit(OpCodes.Ldarg_S, x);
            }
            if (numParams > 1)
            {
                for (int y = 0; y < (numParams - 1); y++)
                {
                    switch (mthdAction)
                    {
                        case "A":
                            ILout.Emit(OpCodes.Add);
                            break;
                        case "M":
                            ILout.Emit(OpCodes.Mul);
                            break;
                        default:
                            ILout.Emit(OpCodes.Add);
                            break;
                    }
                }
            }
            ILout.Emit(OpCodes.Ret);
        }
    }
}