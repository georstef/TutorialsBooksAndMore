using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_chapter6_inheritance_beehive
{
  class Queen:Bee
  {
    private Worker[] workers;
    private int shiftNumber = 0;

    public Queen(Worker[] workers) 
    {
      this.workers = workers;
      HoneyConsumptionRate = 1;
    }

    public bool AssignWork(string work, int shifts)
    {
      Eat(); //my version -> the queen eats only when she assigns jobs
      foreach (Worker worker in this.workers)
      {
        if (worker.DoThisJob(work, shifts)) 
        {
          return true;
        }
      }
      return false;
    }

    public string NextShift() 
    {
      shiftNumber += 1;

      string beesReport = "";
      for (int i=0; i<workers.Length;i++)
      {
        beesReport += string.Format("Bee: #{0}  {1}\n", i.ToString(), workers[i].ShiftPassed());
      }

      return string.Format("Report #{0} Queen Consumption: {1}\n{2}", shiftNumber, HoneyConsumed, beesReport);
    }
  }
}
