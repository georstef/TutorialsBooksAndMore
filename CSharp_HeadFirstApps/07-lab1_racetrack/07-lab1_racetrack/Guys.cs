using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07_lab1_racetrack
{
  class Guys
  {
    public string name;
    private int cash;
    public Bet bet;

    public Guys(string nameIn, int cashIn)
    {
      this.name = nameIn;
      this.cash = cashIn;
      this.bet = null;
    }

    public string getBet()
    {
      if (bet == null)
      {
        return string.Format("{0} no bet", name);
      }
      else 
      {
        return string.Format("{0} bets {1}", name, bet.getBet());
      }
    }

    public void checkBet(Dog winner)
    {
      if (bet != null)
      {
        if (bet.hasWon(winner))
        {
          cash += bet.money;
        }
        else
        {
          cash -= bet.money;
        }
      }
      bet = null;
    }

    public string getName()
    {
      return string.Format("{0} cash({1})", name, cash);
    }

    public bool cashRepository(int betCash)
    {
      return (cash >= betCash);
    }
  }
}
