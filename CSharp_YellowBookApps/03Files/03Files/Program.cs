using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

enum TraficLight
{ 
  Red,
  Amber,
  Green
};

namespace ConsoleApplication1
{
  class Program
  {
    static void Main(string[] args)
    {
      /* writing to a file
      StreamWriter writer = new StreamWriter(@"D:\Programming\c#\04 c# yellow book\apps\03Files\test.txt");
      writer.WriteLine("Hello World!!!");
      writer.Close();
      */

      /* reading from a file */
      StreamReader reader = new StreamReader(@"D:\Programming\c#\04 c# yellow book\apps\03Files\test.txt");
      while (! reader.EndOfStream)
      {
        Console.WriteLine(reader.ReadLine());
      }
      reader.Close();

      TraficLight myLight = TraficLight.Green;
      Console.WriteLine(myLight);

      Console.ReadKey();
    }
  }
}
