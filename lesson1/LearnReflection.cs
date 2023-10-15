
using Lesson.LearnSearchFromAssembly;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Loader;

namespace Lesson;

public class LearnReflection
{
    public static void Main()
    {
        var assemblies=AppDomain.CurrentDomain.GetAssemblies();
        var onlyOurAssembly=assemblies
            //фільтруємо по атрибуту Authors в збірці
            .Where(x=>((AssemblyCompanyAttribute)x.GetCustomAttributes(typeof(AssemblyCompanyAttribute),true).FirstOrDefault()!)?.Company=="Abanking")
            .ToList();

        var searchClassList=onlyOurAssembly
            .SelectMany(val=>val.GetTypes())
            // фільтруємо по тих параметрах які нам треба
            .Where(myType=>myType.IsClass&& !myType.IsAbstract&& typeof(ITestSearch).IsAssignableFrom(myType))
            .ToList();

        var withAttribute = searchClassList
              .Where(myType=>myType.GetCustomAttributes(typeof(TestSearchAttribute),true).Length!=0)
              .ToList();

        foreach (var testClass in searchClassList)
        {
            // для того щоб отримати саме значення треба вже звернутися до інстансу класу
            // це можна зробити через Activator
            var classInstance = Activator.CreateInstance(testClass);
            
            //для того щоб подивитися приватні поля класу треба створити його інстанс
            // можна  взагалі витягнути всю метаінфу
            var clientid = testClass.GetField("TestInfo", BindingFlags.NonPublic | BindingFlags.Instance)?.GetValue(classInstance);
            Console.WriteLine(clientid);
        }
        foreach (var testClass in searchClassList)
        {
            var method = testClass.GetProperty(nameof(ITestSearch.Count))?.GetGetMethod();
           // скомпільовує та створює інстанс методу 
            var dynamicMethod=new DynamicMethod("Ugly",typeof(int),Type.EmptyTypes);
            var generator=dynamicMethod.GetILGenerator();
            generator.Emit(OpCodes.Ldnull);
            generator.Emit(OpCodes.Call,method);
            generator.Emit(OpCodes.Ret);
            // Acion Func Predicat делегати
            var ugly  = (Func<int>)dynamicMethod.CreateDelegate(typeof(Func<int>));
            Console.WriteLine(ugly());
        }

    }

    public void LoadAssemblyTest()
    {
        //динамічна загрузка збірок 
        // за допомогою стріма
        var dllPath = "path to dll";
        using var fileStream=new FileStream(dllPath,FileMode.Open);
        //поміщаємо в цю змінну збірку
        var assemblyContext = new AssemblyLoadContext("test");
        
        var assembly= assemblyContext.LoadFromStream(fileStream);
        // щоб збірка реально була видалена треба видалити всі силки на неї
        assemblyContext.Unload();
    }
}


//Assembly.GetEntryAssembly -  представляє головну (вхідну) збірку, яка була використана для запуску програми.