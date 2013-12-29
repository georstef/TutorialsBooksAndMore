using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_chapter7_polymorphism
{
  //------------------------------------------------------------
  class Room : Location
  {
    private string decoration;

    public Room(string name, string decorationIn): base(name)
    {
      this.decoration = decorationIn;
    }

    public override string Description
    {
      get
      {
        return base.Description + string.Format("\nDecoration: {0}", this.decoration);
      }
    }

  }

  //------------------------------------------------------------
  class RoomWithDoor : Room, IHasExteriorDoor
  {
    public RoomWithDoor(string name, string decorationIn, string DoorDescIn): base(name, decorationIn)
    {
      this.DoorDesc = DoorDescIn;
    }

    public string DoorDesc { get; set; }
    public Location DoorLocation { get; set; }
  }

}
