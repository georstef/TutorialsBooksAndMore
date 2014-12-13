using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlazerCalc
{
  class Program
  {
    static void Main()
    {
      double width, height, wLength, gArea;
      string widthString, heightString;

      /*
      Console.Write("Give width: ");
      widthString = Console.ReadLine();
      double.Parse(widthString);
      */
      width = getDouble("Give width: ");

      /*
      Console.Write("Give height: ");
      heightString = Console.ReadLine();
      height = double.Parse(heightString);
      */
      height = getDouble("Give height: ");

      wLength = 2 * (width + height) * 3.25;
      gArea = 2 * (width + height);

      Console.WriteLine("The Length is {0:0.000}", wLength);
      Console.WriteLine("The Area is {0:0.0}", gArea);
      Console.ReadLine();

      for (int i = 0; i <= 3; i++) // i++ = i+=1
      {
        Console.WriteLine(i);        
      }

      float x = 1;
      int k = (int)x;
      Console.WriteLine("\x0041BCDE\a"); //ABCDE and beep (A=\x0041 and beep=\a)
      Console.WriteLine(5/2.0);
      Console.ReadLine();
    }

    static double getDouble(string message)
    {
      Console.Write(message);
      var response = Console.ReadLine();
      return double.Parse(response);
    }
  }
}
