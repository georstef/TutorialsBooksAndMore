using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10LibraryDLL
{
  public class MyDLLClass
  {
    public static void WriteFromDLL(string s)
    {
      Console.WriteLine("From dll: "+s);
    }
  }
}
