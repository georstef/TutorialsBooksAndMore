using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_chapter7_polymorphism
{
  //------------------------------------------------------------
  interface IHasExteriorDoor
  {
    string DoorDesc { get; }
    Location DoorLocation { get; set; }
  }
}
