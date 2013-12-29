using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_chapter8_enums
{
  enum Suits {Spades, Clubs, Diamonds,Hearts }
  enum Values
  {
    Ace = 1,
    Two = 2,
    Three = 3,
    Four = 4,
    Five = 5,
    Six = 6,
    Seven = 7,
    Eight = 8,
    Nine = 9,
    Ten = 10,
    Jack = 11,
    Queen = 12,
    King = 13
  }

  class Card
  {
    public Suits Suit;
    public Values Value;

    public Card(Suits suit, Values value) 
    {
      this.Suit = suit;
      this.Value = value;
    }

    public string Name
    {
      get {
        return string.Format("{0} of {1}", this.Value.ToString(), this.Suit.ToString()); 
      }    
    }

    public override string ToString()
    {
      return this.Name;
    }
  }

  //-----------------------------------------
  class CardComparer_bySuit : IComparer<Card>
  {
    public int Compare(Card x, Card y)
    {
      if (x.Suit > y.Suit)
        return 1;
      if (x.Suit < y.Suit)
        return -1;
      if (x.Value > y.Value)
        return 1;
      if (x.Value < y.Value)
        return -1;
      return 0;
    }
  }
}
