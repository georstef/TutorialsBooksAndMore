using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_chapter7_polymorphism
{
  //------------------------------------------------------------
  abstract class Location
  {
    public string Name { get; private set; }
    public Location[] Exits;

    public Location(string name) 
    {
      Name = name;
    }

    public virtual string Description
    {
      get
      {
        string result = string.Format("{0}\nExits: ", Name);
        for (int i = 0; i < Exits.Length; i++)
			  {
          result += string.Format("[{0}] ", Exits[i].Name);
			  }
        return result;
      }
    
    }
  }
}
