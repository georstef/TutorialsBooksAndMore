using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; //must use this
using System.Diagnostics;//for processes

namespace _08Threads
{
  class Program
  {
    static private void busyLoop() { 
      long count; 
      for (count = 0; count < 10000000000; count = count + 1) 
      { 
        //do nothing just count
      } 
    }
    
    static void Main(string[] args)
    {
      ThreadStart busyLoopMethod = new ThreadStart(busyLoop);
      Thread t1 = new Thread(busyLoopMethod);
      Thread t2 = new Thread(busyLoopMethod);

      t1.Start();
      if (Console.ReadKey().Key == ConsoleKey.Escape)
      {
        t1.Abort();
      }
      //busyLoop();
      //t2.Start();

      Process p1 = new Process();
      p1.StartInfo.FileName = "notepad.exe";
      p1.Start();

      if (Console.ReadKey().Key == ConsoleKey.Escape)
      {
        p1.Kill();
      }


      Console.ReadKey();
    }
  }
}
