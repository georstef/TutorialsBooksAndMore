using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _09_chapter7_polymorphism
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    RoomWithDoor LivingRoom;
    RoomWithDoor Kitchen;
    Room DiningRoom;

    OutsideWithDoor FrontYard;
    OutsideWithDoor BackYard;
    Outside Garden;

    Location currentLocation;

    public MainWindow()
    {
      InitializeComponent();
      CreatePlaces();
      changeLocation(LivingRoom);
    }

    public void CreatePlaces()
    {
      LivingRoom = new RoomWithDoor("Living Room", "Sofa, TV", "Front door");
      Kitchen = new RoomWithDoor("Kitchen", "Refrigerator", "Back door");
      DiningRoom = new Room("DiningRoom", "Table, Chairs");

      FrontYard = new OutsideWithDoor("Front Yard", true, "Front door");
      BackYard = new OutsideWithDoor("Back Yard", true, "Back door");
      Garden = new Outside("Garden", true);

      LivingRoom.Exits = new Location[] {DiningRoom, FrontYard};
      Kitchen.Exits = new Location[] { DiningRoom, BackYard};
      DiningRoom.Exits = new Location[] {Kitchen, LivingRoom};

      LivingRoom.DoorLocation = FrontYard;
      Kitchen.DoorLocation = BackYard;

      FrontYard.Exits = new Location[] { Garden, LivingRoom };
      Garden.Exits = new Location[] { FrontYard, BackYard };
      BackYard.Exits = new Location[] { Garden, Kitchen};

      FrontYard.DoorLocation = LivingRoom;
      BackYard.DoorLocation = Kitchen;
    }

    private void changeLocation(Location location)
    {
      currentLocation = location;
      lblDescription.Text = location.Description;
      edtCombo.Items.Clear();
      foreach (Location l in location.Exits)
			{
			   edtCombo.Items.Add(l.Name);
			}
      edtCombo.SelectedIndex = 0;

      if (location is IHasExteriorDoor)
      {
        btnPassTheDoor.IsEnabled = true;
      }
    }

    private void btnGo_Click(object sender, RoutedEventArgs e)
    {
      changeLocation(currentLocation.Exits[edtCombo.SelectedIndex]);
    }

    private void btnPassTheDoor_Click(object sender, RoutedEventArgs e)
    {
      if (currentLocation is IHasExteriorDoor)
      {
        changeLocation((currentLocation as IHasExteriorDoor).DoorLocation);
      }
    }


  }
}
