using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace MicroServiceNet
{
    public class ConstrutorClasse
    {
        AssemblyName asemblyName;

        public ConstrutorClasse(string ClassName)
        {
            this.asemblyName = new AssemblyName(ClassName);
        }



        public Type CriarClasse(string[] MethodsNames, Type[] Types)
        {
            TypeBuilder DynamicClass = this.CreateClass();
            this.CreateConstructor(DynamicClass);
            for (int ind = 0; ind < MethodsNames.Count(); ind++)
                CreateMethod(DynamicClass, MethodsNames[ind], Types[ind]);
            return DynamicClass.CreateType();
        }

        private void CreateMethod(TypeBuilder dynamicClass, object p1, object p2)
        {
            
        }

        private TypeBuilder CreateClass()
        {
            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(this.asemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            TypeBuilder typeBuilder = moduleBuilder.DefineType(this.asemblyName.FullName,
                                TypeAttributes.Public |
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
            typeBuilder.DefineDefaultConstructor(MethodAttributes.Public | 
                                                 MethodAttributes.SpecialName | 
                                                 MethodAttributes.RTSpecialName);
        }
    }
}
