using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _15_ExtendSealed
{
  //sealed classes cannot be inherited
  sealed class SealedClass
  {
    public void PrintSomething() 
    {
      Console.WriteLine("Something");
    }
  }
  
  //
  static class ExtensionClass
  {
    //in order to make this an extension method 
    //1) it must be a static method
    //2) it must be inside a static class
    //3) the first parameter must be of type "this SealedClass"
    public static void PrintSomethingElse(this SealedClass sc)
    { 
      Console.WriteLine("Something Else");
    }
  }
  
  class Program
  {
    static void Main(string[] args)
    {
      SealedClass s = new SealedClass();
      s.PrintSomething();
      s.PrintSomethingElse();//<-note that it now "s" has this method too
      Console.ReadKey();
    }
  }
}
