using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_lab1_racetrack
{
  class Bet
  {
    public Dog dog = null;
    public int money = 0;

    public bool hasWon(Dog winner)
    {
      return (dog == winner);
    }

    public string getBet()
    {
      return string.Format("${0} on dog in lane {1}", money.ToString(), dog.lane);
    }

  }
}
