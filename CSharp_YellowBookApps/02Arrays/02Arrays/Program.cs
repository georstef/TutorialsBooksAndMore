using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
  class Program
  {
    //input string
    static string readString(string prompt) 
    { 
      string result; 
      do 
      {
        Console.Write(prompt);
        result = Console.ReadLine(); 
      } 
      while (result == ""); 
      return result; 
    }

    //input integer
    static int readInt(string prompt, int low, int high) 
    { 
      int result; 
      do 
      { 
        string intString = readString(prompt);
        try
        {
          result = int.Parse(intString);
        }
        catch (FormatException e)
        {
          Console.WriteLine("1. Specific Error. Try again. {0}", e.Message);
          result = low-1;
        }
        catch (Exception e)
        {
          Console.WriteLine("2. Generic Error. Try again. {0}", e.Message);
          result = low - 1;
        }

        switch (result)
        {
          case 1: //cannot do range 1..5 (use "if else if" instead)
            Console.WriteLine("it's 1");
            break;

	        default:
            Console.WriteLine("other");
            break;
        }
      }
      while ((result < low) || (result > high)); 
      return result; 
    }

    static void Main(string[] args)
    {
      int[] scores = new int[3];//from 0..2
      for (int i = 0; i < 3; i++)
			{
        scores[i] = readInt("Give score: ", 0 ,1000);
			}
			 
    }
  }
}
