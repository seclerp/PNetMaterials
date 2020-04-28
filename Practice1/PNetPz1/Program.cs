using System;

namespace Delegates
{
  class Program
  {
    // 1
    class A
    {
    }

    class B : A
    {
    }

    class Printer
    {
      public void Print(B b)
      {
        Console.WriteLine("B b was printed");
      }
    }

    private delegate A BaseDelegate();

    private static B Gav()
    {
      Console.WriteLine("GAV");
      return new B();
    }

    private static void Gav2(A a)
    {
      Console.WriteLine("GAV");
    }

    private delegate void BaseDelegate2(B b);

    private delegate IPerson ManDelegate(string name); // Ковариантность

    private void GetPersonName(IPerson person)
    {
      Console.WriteLine(person.GetType());
    }


    private Man GetManName(string name)
    {
      return new Man(name);
    }

    // 2

    private delegate void DelegateForStatic(string message);

    private static void StaticMethod(string message)
    {
      Console.WriteLine(message);
    }

    // 5

    private delegate void DelegateForChains();

    private static void ChainMethod1()
    {
      Console.WriteLine("Method1");
    }

    private static void ChainMethod2()
    {
      Console.WriteLine("Method2");
    }

    // 7

    private delegate double PowDelegate(double @base, double exponent);

    // 9

    private static event Action MyEvent;

    private static void EventMethod()
    {
      Console.WriteLine("Event works");
    }

    // Main

    static void Main(string[] args)
    {
      // 1

      var program = new Program();
      var printer = new Printer();

      BaseDelegate aa = Gav;
      BaseDelegate2 bb = Gav2;
      
      // 2

      DelegateForStatic delegateForStatic = StaticMethod;
      delegateForStatic("Static method works");
      

      // 3

      Console.WriteLine();
      BaseDelegate2 printerDelegate = printer.Print;
      printerDelegate.Invoke(new B());
      
      // 4
      var del = new Action<string>(str => Console.Write(str));
      del("adsfdsfdsdfsdf");
      del?.Invoke("adsfdsfdsdfsdf");
      // 5

      Console.WriteLine();
      DelegateForChains d1 = ChainMethod2;
      DelegateForChains d2 = ChainMethod1;
      DelegateForChains d3 = ChainMethod1;

      d3 += d1;
      d3 += d2;
      d3 += d2;
      d3 -= d2;
      d3();

      // 6

      var dels = d3.GetInvocationList();

      Console.WriteLine();
      foreach (var d in dels)
      {
        if (nameof(ChainMethod1) == d.Method.Name)
          d.DynamicInvoke();
      }

      // 7

      Console.WriteLine();

      Func<double, double, double> genDel = (a, b) => Math.Pow(a, b);
      Console.WriteLine(genDel(2, 3));

      PowDelegate powDel = (a, b) => Math.Pow(a, b);
      Console.WriteLine(powDel(3, 2));

      // 9

      Console.WriteLine();
      MyEvent += EventMethod;
      MyEvent();
    }
  }

  interface IPerson
  {
    string Name { get; set; }
  }

  class Person : IPerson
  {
    public string Name { get; set; }

    public Person(string name)
    {
      Name = name;
    }
  }

  class Man : Person
  {
    public Man(string name) : base(name)
    {
    }
  }
}