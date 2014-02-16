using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _16_chapter14_linq
{
  enum PriceRange { Cheap, Midrange, Expensive } //must be in a namespace but out of a class

  class Comic
  {
    public string Name { get; set; }
    public int Issue { get; set; }
  }

  class Program
  {
    static void Main(string[] args)
    {
      //SIMPLE
      int[] somearray = new int[] { 2, 4, 5, 7, 8 };
      IEnumerable<int> anotherarray = from item in somearray 
                                      where item >= 5
                                      orderby item descending
                                      select item;
      foreach (int item in somearray)
      {
        Console.WriteLine("somearray: {0}", item);
      }
      foreach (int item in anotherarray)
      {
        Console.WriteLine("linq-ed: {0}", item);
      }

      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");

      //WITH OUTSIDE "CONNECTION"

      IEnumerable<Comic> comics = BuildCatalog();
      Dictionary<int, double> values = GetPrices();

      var mostExpensive = from comic in comics 
                          where values[comic.Issue] > 500
                          orderby values[comic.Issue] descending
                          select comic;

      foreach (Comic comic in mostExpensive)
      {
        Console.WriteLine("{0} is worth {1}$", comic.Name, values[comic.Issue]);
      }

      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");

      //GROUPS

      var priceGroups = from pair in values
                        group pair.Key by GetPriceGroup(pair.Value) into priceGroup //GetPriceGroup(pair.Value) is the Key of the newly created priceGroup
                        orderby priceGroup.Key descending
                        select priceGroup;//returns a group of values (the group has 3 entries and each one has some integers - keys from the dictionary)

      foreach (var group in priceGroups)
      {
        Console.Write("I found {0} {1} comics: issues ", group.Count(), group.Key);
        //group.Count() <- shows how many integers are into this group
        foreach (var issueNumber in group) //issueNumber = the key/int part of the Dictionary<int, double>
          Console.Write("#" + issueNumber.ToString() + " ");
        Console.WriteLine();
      }

      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");
      Console.WriteLine("-----------------------");

      //JOIN

      var name_and_price = from comic in comics
                           join price in values
                           on comic.Issue equals price.Key
                           orderby comic.Issue
                           select new { comic.Issue, comic.Name, price.Value }; //this is an anonymous type (new without type)

      foreach (var comic_with_price in name_and_price)
      {
        Console.WriteLine("{0} {1} is worth {2}$", comic_with_price.Issue, comic_with_price.Name, comic_with_price.Value);
      }

      Console.ReadKey();
    }

    private static IEnumerable<Comic> BuildCatalog()
    {
      return new List<Comic> {
        new Comic { Name = "Johnny America vs. the Pinko", Issue = 6 },
        new Comic { Name = "Rock and Roll (limited edition)", Issue = 19 },
        new Comic { Name = "Woman’s Work", Issue = 36 },
        new Comic { Name = "Hippie Madness (misprinted)", Issue = 57 },
        new Comic { Name = "Revenge of the New Wave Freak (damaged)", Issue = 68 },
        new Comic { Name = "Black Monday", Issue = 74 },
        new Comic { Name = "Tribal Tattoo Madness", Issue = 83 },
        new Comic { Name = "The Death of an Object", Issue = 97 },
      };
    }

    private static Dictionary<int, double> GetPrices()
    {
      return new Dictionary<int, double> {
        { 6, 3600 },
        { 19, 500 },
        { 36, 650 },
        { 57, 13525 },
        { 68, 250 },
        { 74, 75 },
        { 83, 25.75 },
        { 97, 35.25 },
      };
    }

    private static PriceRange GetPriceGroup(double price)
    {
      if (price < 100)
      {
        return PriceRange.Cheap;
      }
      else if (price < 1000)
      {
        return PriceRange.Midrange;
      }
      else
      {
        return PriceRange.Expensive;
      }
    }

  }
}
