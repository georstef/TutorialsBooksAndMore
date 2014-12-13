using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _10LibraryDLL;

namespace _10LibraryUse
{
  class Program
  {
    static void Main(string[] args)
    {
      MyDLLClass.WriteFromDLL("this");

      Console.ReadKey();
    }
  }
}
