//using RestSharp;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.Composition;
//using System.Linq;
//using System.Reflection;
//using System.Reflection.Emit;
//using System.Text;
//using System.Threading.Tasks;

//namespace MicroServiceNet
//{
//    public class GerenciadorDeClasse
//    {
//        public static object CreateNewObject(Dictionary<string, Type> dicionario)
//        {
//            var myType = CompileResultType(dicionario);
//            return Activator.CreateInstance(myType);
//        }

//        private static TypeBuilder GetTypeBuilder(string libraryName = "MainModule", string typeSignature = "MyDynamicType")
//        {
//            var an = new AssemblyName(typeSignature); // Aqui você vai definir o nome da classe dinâmica
//            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(an, AssemblyBuilderAccess.Run);
//            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(libraryName); // Aqui vai definir em qual Class Library sua classe dinâmica vai estar

//            TypeBuilder tb = moduleBuilder.DefineType(typeSignature,
//                    TypeAttributes.Public |
//                    TypeAttributes.Class |
//                    TypeAttributes.AutoClass |
//                    TypeAttributes.AnsiClass |
//                    TypeAttributes.BeforeFieldInit |
//                    TypeAttributes.AutoLayout,
//                    null);

//            var attrCtorParams1 = new Type[] { typeof(Type) };
//            var attrCtorInfo1 = typeof(ExportAttribute).GetConstructor(attrCtorParams1);
//            var attrBuilder1 = new CustomAttributeBuilder(attrCtorInfo1, new object[] { typeof(IProductService) });
//            tb.SetCustomAttribute(attrBuilder1);

//            var attrCtorParams2 = new Type[] { typeof(string) };
//            var attrCtorInfo2 = typeof(MicroServiceHostAttribute).GetConstructor(attrCtorParams2);
//            var attrBuilder2 = new CustomAttributeBuilder(attrCtorInfo2, new object[] { "Some Value" });
//            tb.SetCustomAttribute(attrBuilder2);
//            return tb;
//        }


//        public static Type CompileResultType(Dictionary<string, Type> dicionario) // Repare que já mudei aqui pra você
//        {
//            TypeBuilder tb = GetTypeBuilder(); // Aqui constrói a classe num Assembly "MainModule.dll", classe "MyDynamicType". 
//                                               // Parametrize da forma que achar melhor. 
//            ConstructorBuilder constructor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);

//            foreach (KeyValuePair<string, Type> chaveValor in dicionario)
//            {
//                Type[] parametros = { typeof(List<KeyValuePair<object, object>>) };
//                AddMethodDynamically(tb, "nome do metodo", parametros, typeof(IRestResponse), "A");
//            }

//            Type objectType = tb.CreateType();
//            return objectType;
//        }


//        public static void AddMethodDynamically(TypeBuilder myTypeBld, string mthdName, Type[] mthdParams, Type returnType, string mthdAction)
//        {
//            MethodBuilder myMthdBld = myTypeBld.DefineMethod(mthdName, MethodAttributes.Public | MethodAttributes.Static, returnType, mthdParams);
//            ParameterBuilder myParameterBuilder = myMthdBld.DefineParameter(1, ParameterAttributes.Optional | ParameterAttributes.HasDefault, "parameters");

//            var attrCtorParams = new Type[] { typeof(string) };
//            var attrCtorInfo = typeof(MicroServiceAttribute).GetConstructor(attrCtorParams);
//            var attrBuilder = new CustomAttributeBuilder(attrCtorInfo, new object[] { "Some Value" });
//            myMthdBld.SetCustomAttribute(attrBuilder);




//            ILGenerator ILout = myMthdBld.GetILGenerator();

//            int numParams = mthdParams.Length;

//            for (byte x = 0; x < numParams; x++)
//            {
//                ILout.Emit(OpCodes.Ldarg_S, x);
//            }

//            if (numParams > 1)
//            {
//                for (int y = 0; y < (numParams - 1); y++)
//                {
//                    switch (mthdAction)
//                    {
//                        case "A":
//                            ILout.Emit(OpCodes.Add);
//                            break;
//                        case "M":
//                            ILout.Emit(OpCodes.Mul);
//                            break;
//                        default:
//                            ILout.Emit(OpCodes.Add);
//                            break;
//                    }
//                }
//            }
//            ILout.Emit(OpCodes.Ret);
//        }



//    }
//}
