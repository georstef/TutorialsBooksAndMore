using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06_chapter4_random_menu
{
  class MenuMaker
  {
    public Random Randomizer;
    string[] Meats = { "Roast beef", "Salami", "Turkey", "Ham", "Pastrami" };
    string[] Condiments = { "yellow mustard", "brown mustard", "honey mustard", "mayo", "relish", "french dressing" };
    string[] Breads = { "rye", "white", "wheat", "pumpernickel", "italian bread", "a roll" };

    public string GetMenuItem()
    {
      return Meats[Randomizer.Next(Meats.Length)] + " with " +
             Condiments[Randomizer.Next(Condiments.Length)] + " on " +
             Breads[Randomizer.Next(Breads.Length)]; ;
    }

  }
}
