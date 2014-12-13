using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_chapter6_inheritance_beehive
{
  class Worker: Bee
  {
    private string[] jobs;

    private string currentJob;
    private int currentJobShifts;

    private int shiftsDone;
    private int shiftsToDo;
    
    public Worker(string[] jobs)
    {
      this.jobs = jobs;
    }

    public bool DoThisJob(string work, int shifts)
    {
      if ((String.IsNullOrEmpty(currentJob)) && (jobs.Contains(work)))
      {
        HoneyConsumptionRate = 2;//my version -> the worker eats only when he does a job
        currentJob = work;
        currentJobShifts = shifts;
        return true;
      }
      else
      {
        return false;
      }
    }

    public string ShiftPassed()
    {
      Eat();
      if (!String.IsNullOrEmpty(currentJob))
      {
        if (shiftsDone < currentJobShifts)
        {
          shiftsDone += 1;
          shiftsToDo = currentJobShifts - shiftsDone;
        }
        else 
        {
          currentJob = "";
          shiftsDone = 0;
          shiftsToDo = 0;
        }
      }
      if (shiftsToDo == 0)
      {
        HoneyConsumptionRate = 0;//my version -> job done eating done
      }
      if (String.IsNullOrEmpty(currentJob))
      {
        return string.Format("*** no job at this point *** (Honey Consumed:{0})", HoneyConsumed);
      }
      return string.Format("Job: {0} for {1} more shift(s) (Honey Consumed:{2})", currentJob, shiftsToDo, HoneyConsumed);
    }
  }
}
