using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _08_chapter6_inheritance_beehive
{
  class Bee
  {
    public double HoneyConsumed = 0;
    public double HoneyConsumptionRate { get; set; }

    public void Eat()
    {
      HoneyConsumed += HoneyConsumptionRate;
    }
  }
}
