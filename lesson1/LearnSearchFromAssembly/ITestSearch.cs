

namespace Lesson.LearnSearchFromAssembly;

    public interface ITestSearch
    {
        public int Count { get; }
    }

public class TestSearchAttribute : Attribute
{

}

public class TestSearch1 : ITestSearch
    //єдиний міус в цьому це те що new не приймає ніяких параметрів
    //where T : new()
{
    public int Count => 10;

    private string TestInfo = "hello world 1";
    public TestSearch1()
        {
        //var test= new T();
        //Цей спосіб дозволяє створювати об'єкти навіть тоді, коли тип T не відомий на етапі компіляції.
        //var test2 = Activator.CreateInstance<T>();
    }
}

[TestSearch]
public class TestSearch2 : ITestSearch
{
    public int Count => 20;
    private string TetsInfo= "hello world 1";
}