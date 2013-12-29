using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09_chapter7_polymorphism
{
  //------------------------------------------------------------
  class Outside: Location
  {
    private bool hot;//???

    public Outside(string name, bool hotIn): base(name)
    {
      this.hot = hotIn;
    }

    public override string Description
    {
      get
      {
        string Desc = base.Description;
        if (hot)
          Desc += "\nIt's hot";
        return Desc;
      }
    }
  }

  //------------------------------------------------------------
  class OutsideWithDoor : Outside, IHasExteriorDoor
  {
    public OutsideWithDoor(string name, bool hotIn, string DoorDescIn): base(name, hotIn)
    {
      this.DoorDesc = DoorDescIn;
    }

    public override string Description
    {
      get
      {
        return base.Description + string.Format("\nDoor Desc: {0}", this.DoorDesc);
      }
    }

    public string DoorDesc { get; set; }
    public Location DoorLocation { get; set; }
  }

}
