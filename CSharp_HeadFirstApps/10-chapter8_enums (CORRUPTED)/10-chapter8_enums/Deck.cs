using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10_chapter8_enums
{
  class Deck
  {
    //public Card[] cards = new Card[52];
    public List<Card> cards = new List<Card>();

    //-------------------------------------
    public Deck(bool populate = true)
    {
      if (populate)
      {
        this.Populate();
      }
    }

    //-------------------------------------
    public void Populate()
    {
      int i = 0;
      foreach (Suits s in Enum.GetValues(typeof(Suits)))
      {
        foreach (Values v in Enum.GetValues(typeof(Values)))
        {
          AddCard(new Card(s, v));
          i++;
        }
      }
    }

    //-------------------------------------
    public void AddCard(Card card)
    {
      cards.Add(card);
    }

    //-------------------------------------
    public void RemoveCard(int position)
    {
      cards.RemoveAt(position);
    }

    //-------------------------------------
    public void Empty()
    {
      cards.Clear();
    }

    //-------------------------------------
    public void Sort()
    {
      //sorts by Suit
      cards.Sort(new CardComparer_bySuit());
    }
  }
}
