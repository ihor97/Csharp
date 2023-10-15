using Lesson;
using System.Reflection;

public static class ProxyByReflection
    {
    public static void Main() {
        //проксі можна створювати навколо інтерфейсів
        //CreateProxy(new Hello()) типізуємо його якимось інтерфейсом
        var hello = HelloDispatchproxy<IHello>.CreateProxy(new Hello());
        //перехоплюємо метод SayHello
        hello.SayHello("Student");
    }
    interface IHello
    {
        bool SayHello(string name);
    }
    class Hello : IHello { 
        public bool SayHello(string name)
        {
            Console.WriteLine($"Hello {name}");
            return true;
        }
    }
    class HelloDispatchproxy<T>:DispatchProxy where T : class, IHello
    {
        private IHello Target { get; set; }
        protected override object? Invoke(MethodInfo targetMethod, object[] args)
        {
            var result = targetMethod.Invoke(Target, args);
            return result;
        }
        public static T CreateProxy(T target)
        {
            var proxy = Create<T,HelloDispatchproxy<T>>() as HelloDispatchproxy<T>;
            proxy.Target = target;  
            return proxy as T;
        }
    }
    }

// за допомогою рефлексії ми можемо взнати все про тип 