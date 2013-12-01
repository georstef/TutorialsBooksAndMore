using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _06Delegates
{
  class Program
  {
    delegate void MyDelegate(string s);
    delegate void PrintDelegate();

    public static void Hello(string s)
    {
      Console.WriteLine("  Hello, {0}!", s);
    }

    public static void Goodbye(string s)
    {
      Console.WriteLine("  Goodbye, {0}!", s);
    }

    public static void Print_One()
    {
      Console.WriteLine("One");
    }

    public static void Print_Two()
    {
      Console.WriteLine("Two");
    }

    public static void Main()
    {
      MyDelegate a, b, c, d;
      PrintDelegate p1, p2;

      // Create the delegate object a that references 
      // the method Hello:
      a = new MyDelegate(Hello);
      // Create the delegate object b that references 
      // the method Goodbye:
      b = new MyDelegate(Goodbye);
      // The two delegates, a and b, are composed to form c: 
      c = a + b;
      // Remove a from the composed delegate, leaving d, 
      // which calls only the method Goodbye:
      d = c - a;

      Console.WriteLine("Invoking delegate a:");
      a("A");
      Console.WriteLine("Invoking delegate b:");
      b("B");
      Console.WriteLine("Invoking delegate c:");
      c("C");
      Console.WriteLine("Invoking delegate d:");
      d("D");

      p1 = new PrintDelegate(Print_One);
      p1();
      p2 = new PrintDelegate(Print_Two);
      p2();
      Console.ReadKey();
    }
  }
}
