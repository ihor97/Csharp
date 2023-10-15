

namespace Lesson;

public class LearnDomain
{
    public static void Main()
    {
        // не можна створювати піддоменів
        // текущий домен приложения
        var currentDomain = AppDomain.CurrentDomain;
        //о
        var newDomain = AppDomain.MonitoringIsEnabled;

        //var currentType = currentDomain.CreateInstance("assemblyName", "typeName")?.Unwrap();
        //список сборок приложения
        var assemblyList=currentDomain.GetAssemblies().ToList();

    }
}
