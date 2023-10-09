

//var person = new Person();
//var person2= person;
//person2.Age = 1;

//Console.WriteLine(person2.Age);
//Console.WriteLine(person.Age);


//public class Person
//{
//    // властивість це пара методів get set
//    private int _age;

//    public int Age { get; set; }

//    public Person() { 

//    }


//    ~Person()
//    {
//        // деструктор 
//    }
//    public void Log(string message)
//    {
//        Console.WriteLine(message);
//    }
//}

//*******************************************************************

//public interface IPerson
//{
//    int Age { get; set; } 
//    //можна також реалізовувати методи по замовчуванню
//    void Move()
//    {
//        Console.WriteLine("");
//    }
//}

//*******************************************

//var count = 1;
//public struct Student
//{

//}

//*******************************************

//статичні класи їх правда вартує опускати в OOП

//var data = "skmpksmcpks";

//var newData= data.DeleteFirstCharExtension();
//var newData2= StringHelper.DeleteFirstChar(data);

//public static class StringHelper
//{
//    public static string DeleteFirstChar(string str)
//    {
//        return str;
//    }

//    public static string DeleteFirstCharExtension(this string str)
//    {
//        return str;
//    }
//}

//*******************************************

//public abstract class Car
//{
//    public abstract void Move();
//}

//// internal вказує на доступність тільки в межах збірки
//internal  class Lada : Car
//{
//    public override void Move()
//    {
//        throw new NotImplementedException();    
//    }
//}

//*******************************************
//incapsulation
// модифікатори доступу - 
// sealed - від цього класу не можна унаслідуватися
//using System.Drawing;

//var main=new Main(new []{ new Main.Car("Lada"), new Main.Car("tesla") });


//main.LogInfo();

//public class Main
//{
//    private readonly Car[] _cars;
//    public class Car
//    {
//        //public string Name { get; init } 
//        //var person = new Person { Name = "John" }; - ініціалізація через init а не через конструктор 
//        // конструктор є більш кращим
//        public string Name { get;  }
//        public Color Color { get; set; }
//        public Car(string name) 
//        { 
//        Name= name;
//        }
//    }


//    public Main(Car[] cars)
//    {
//        _cars = cars;
//    }

//    public void LogInfo()
//    {
//        foreach(var car in _cars)
//        {
//            Console.WriteLine($"{car.Name} {car.Color}");
//        }
//    }
//}

//*******************************************

// inheritance

//var car = new Car();

//car.OpenDoor(); 

//var motorbike=new Motorbike();
//motorbike.UseStand();

////краще зробити через інтерфейс
//public interface IGetInfo
//{
//    object GetInfo();
//}
//public class Entity : IGetInfo
//{
//    public object GetInfo()
//    {
//        return new List<int>();
//    }
//}

//public abstract class Transport
//{
//    // так як ми не можемо створити інстанс від абстрактного класу то 
//    // можна метод зробити protected
//    protected void Stop()
//    {

//    }
//    protected abstract void ActionAfterStop();
//}

//public class Car : Transport
//{
//    //агрегація
//    public IGetInfo _entity;

//    public Car(IGetInfo entity) 
//    {
//        _entity = entity;
//    }
//   public void OpenDoor()
//    {
//        ActionAfterStop();
//    }
//    protected override void ActionAfterStop()
//    {
//        throw new NotImplementedException();
//    }
//}

//public class Motorbike : Transport
//{
//   public void UseStand()
//    {
//        ActionAfterStop();
//    }
//    protected override void ActionAfterStop()
//    {
//        throw new NotImplementedException();
//    }
//}


//********************************************
// polymorphism зміна поведінки в залежності від переданих параметрів

//var item = new BaseLogic();
//var superlogic = new SuperLogic();

//var logger1 = new Logger(item);
//logger1.Log(new BaseItem() { Count = 1 });

//var logger2 = new Logger(superlogic);
//logger2.Log(new BaseItem() { Count = 1 });

//Console.ReadLine(); 
//var  item2= new BaseItem2() { Name="vova"};
//class Logger
//{
//    private readonly BaseLogic _baseLogic;

//    public Logger(BaseLogic baseLogic)
//    {
//        _baseLogic = baseLogic;
//    }
//    public void Log(BaseItem baseItem)
//    {
//        var item = _baseLogic.DoAction(baseItem);
//        Console.WriteLine(item);
//    }
//}

//public class BaseItem
//{
//    public int Count { get; set; }
//}

//public class BaseItem2 : BaseItem
//{
//    public string Name { get; set; }
//}

//public class BaseLogic<T> where T : BaseItem
//{
//    // virtual можна перевизначити в класах наслідниках
//    public virtual int DoAction(T baseItem)
//    {

//        return baseItem.Count;
//    }
//}
//// то що ми зробили з дженеріками це є параметричний поліморфізм
//public class SuperLogic<T> : BaseLogic<BaseItem2> 
//{
//    public override int DoAction(BaseItem2 baseItem)
//    {
//        var result = base.DoAction(baseItem);
//        //if(baseItem is BaseItem2 baseitemV2)
//        //{
//        //    return baseItem.Count + baseitemV2.Name.Length;
//        //}
//        return result + baseItem.Name.Length;
//    }
//}

//********************************************
// абстракція - ми оперуємо на рівні інтерфейсу а як він реалізований на рівні класу нас це вже не обходить

//using System.Reflection.Emit;

//public interface IEmploee
//{
//    void PrintInfo();
//}

//public class Manager : IEmploee
//{
//    public string Level { get; set; }
//    public string Name { get; set; }    
//    public void PrintInfo()
//    {
//        Console.WriteLine($"Manager: {Name} Level: {Level}");
//    }
//}

//public class Programmer: IEmploee
//{
//    public string Language { get; set; }
//    public string Name { get; set; }
//    public void PrintInfo()
//    {
//        Console.WriteLine($"Programmer: {Name} Language: {Language}");
//    }
//}

//********************************************
// SOLID - single responsibility
//open closed principle - відкритість для розширення і закритість для змінення

//public interface IConnectionIndentityServer
//{
//    [Obsolete]
//    object Auth(object data);
//    object AuthV2(object data);

//}

//liskov substitution - ми можемо підставити замість одного дочіргього елемента інший і прога не поламається
// принцип розділення інтерфейсу - краще багато малих ніж один великий інтерфейсів
// принцип інверсії залежностей - клас який реалізує деяку логіку повинен робити фасад 
// він повинен  приймати інферфейси і викликати методи їх для отримання якогось результату

//public interface ICompanyConnectionService
//{

//}

//public class CompanyConnectionSrvice; ICompanyConnectionService
//{

//}

//// верхній рівень
//public class CompanyMeneger
//{
//public CompanyMeneger(ICompanyConnectionSrvice service)
//{

//}
//public object GetCompany(int userId)
//    {

//    }
//}

//*****************************************

//IEnumerable - лінивий

//var data = new List<int>() { 1,2,3,4,5};

//var datav2=data.Where(x => x %2== 0);
//var res= datav2.FirstOrDefault();

// різниця між List i Array  в тому що ми не можемо міняти розмір масиву
// list  - це абстракція над масивом щоб можна було з ним зручніше працювати
//var array = new[] { 1, 2, 3, 4 };

//var list = new List<int>() { 1,2,3,4};

//*************************************************
//Threads

//Thread myThread = new Thread(Print);
//Thread myThread1 = new Thread(new ThreadStart(Print));
//Thread myThread2 = new Thread(()=>Console.WriteLine("Hello Threads")); 
//myThread.Start();
//myThread1.Start();
//myThread2.Start();

//void Print() => Console.WriteLine("Hello Threads");

//var x = 0;
//for (var i = 0; i < 3; i++)
//{
//    Thread myThread = new Thread(Print);
//    myThread.Name = $"potok {i}";
//    myThread.Start();
//}
//void Print()
//{
//    x = 1;
//    for(var i = 0; i < 3; i++)
//    {
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//        x++;
//        Thread.Sleep(100);
//    }
//}

//**************************************************/
// синхронізування потоків 
//var x = 0;
//var locker = new object();

//for (int i =  0; i <3; i++)
//{
//        Thread myThread = new Thread(Print);
//        myThread.Name = $"potok {i}";
//       myThread.Start();
//}

//void Print()
//{
//    var acquiredlock = false;
//    try
//    {
//        Monitor.Enter(locker, ref acquiredlock);
//        x = 1;
//        for (var i = 0; i < 3; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//    }
//    finally 
//    {
//        if (acquiredlock)
//        {
//            Monitor.Exit(locker);
//        }
//    }

//}

//************************************/

//var x = 0;
//var mutexobj = new Mutex();

//for (int i = 0; i < 3; i++)
//{
//    Thread myThread = new Thread(Print);
//    myThread.Name = $"potok {i}";
//    myThread.Start();
//}

//void Print()
//{
//    mutexobj.WaitOne();
//        x = 1;
//        for (var i = 0; i < 3; i++)
//        {
//            Console.WriteLine($"{Thread.CurrentThread.Name}: {x}");
//            x++;
//            Thread.Sleep(100);
//        }
//      mutexobj.ReleaseMutex();

//}

//*****************************************/

//while (true)
//{
//	for (int i = 0 ; i <10; i++)
//	{
//		new Reader(i);
//	}
//}

//class Reader
//{
//	static Semaphore sem = new Semaphore(3, 3);
//	Thread myThread;
//	public Reader(int i)
//	{
//		myThread = new Thread(Read);
//		myThread.Name = $"reader {i}";
//		myThread.Start();
//	}
//	public void Read()
//	{
//		sem.WaitOne();
//		Console.WriteLine($"{Thread.CurrentThread.Name} reader enters");
//        Console.WriteLine($"{Thread.CurrentThread.Name} reading");
//		Thread.Sleep(1000);
//		Console.WriteLine($"{Thread.CurrentThread.Name} reader leaves library");
//sem.Release();
//		Thread.Sleep(1000);

//    }
//}

//*********************************************||
//// task - це посуті проміс

//var task1 = new Task(() => Console.WriteLine($"Current Task: {Thread.CurrentThread.ManagedThreadId}"));
//// ContinueWith це аналог then
//var task2 = task1.ContinueWith(t => Console.WriteLine($"Current task: {Task.CurrentId} Previous task: ${t.Id}"));

//var task3 = task1.ContinueWith(t => Console.WriteLine($"Current task: {Task.CurrentId} Previous task: ${t.Id}"));
//var task4 = task1.ContinueWith(t => Console.WriteLine($"Current task: {Task.CurrentId} Previous task: ${t.Id}"));

//task1.Start();
//task4.Wait();
//Console.WriteLine("End.");
//*************************************/

//var watch = new System.Diagnostics.Stopwatch();
//watch.Start();
//await PrintNameAsync("misha");
//await PrintNameAsync("sasha");
//await PrintNameAsync("masha");

//watch.Stop(); 

//Console.WriteLine(watch.ElapsedMilliseconds);

//async Task PrintNameAsync(string name)
//{
//    await Task.Delay(3000);
//    Console.WriteLine(name);
//}