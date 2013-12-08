using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09Exceptions
{
  public class BankException : System.Exception 
  { 
    public BankException(string message) : base(message) 
    {
      WriteStuff("Parent: " + message);
    }

    public BankException()
    {
      //must have this parameter-less method here in the parent
      //so that the child constructor doesn't have to use [:base(message)]
    }
    
    public void WriteStuff(string message)
    {
      Console.WriteLine(message);
    }
  }

  public class MyException: BankException
  {
    public MyException(string message)
    {
      //in C# the parents method is always called before the childs method
      //base.Exception(message); <= does not work

      base.WriteStuff("Child: " + message);
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        if ("john" != "") //inName.Length == 0) 
        {
          throw new MyException("Invalid Name");
        }
      }
      catch (MyException e)
      {
        //Console.WriteLine(e.Message);
        //throw;
      }

      Console.ReadKey();
    }
  }
}
