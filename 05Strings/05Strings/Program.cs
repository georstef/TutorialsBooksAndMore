using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05Strings
{
  class Program
  {
    static void Main(string[] args)
    {
      string s1 = "John";
      string s2 = s1;
      s2 = "another";
      Console.WriteLine(s1 + " " + s2);

      int i1 = 10;
      int i2 = i1;
      i2 = 20;
      Console.WriteLine(i1.ToString() + " " + i2.ToString());

      StringBuilder s3 = new StringBuilder("Barbara");
      s3[2] = 'R';
      Console.WriteLine(s3);
    }
  }
}
