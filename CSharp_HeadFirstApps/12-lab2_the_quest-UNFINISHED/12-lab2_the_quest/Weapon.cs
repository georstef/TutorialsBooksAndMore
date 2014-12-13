using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace _12_lab2_the_quest
{
  interface IPotion
  {
    bool Used { get; }
  }
  
  abstract class Weapon : Mover
  {
    public bool PickedUp { get; private set; }

    public void PickUpWeapon() { PickedUp = true; }
    public abstract string Name { get; }
    public abstract void Attack(Direction direction, Random random);

    public Weapon(Game game, Point location)
      : base(game, location)
    {
      PickedUp = false;
    }
    
    protected bool DamageEnemy(Direction direction, int radius,
    int damage, Random random)
    {
      Point target = game.PlayerLocation;
      for (int distance = 0; distance < radius; distance++)
      {
        foreach (Enemy enemy in game.Enemies)
        {
          if (Nearby(enemy.Location, target, distance))
          {
            enemy.Hit(damage, random);
            return true;
          }
        }
        target = Move(direction, target, game.Boundaries);
      }
      return false;
    }
  }

  class Sword : Weapon
  {
    public Sword(Game game, Point location)
      : base(game, location) { }
    public override string Name { get { return "Sword"; } }
    public override void Attack(Direction direction, Random random)
    {
      // Your code goes here
    }
  }

  class Bow : Weapon
  {
    public Bow(Game game, Point location)
      : base(game, location) { }
    public override string Name { get { return "Sword"; } }
    public override void Attack(Direction direction, Random random)
    {
      // Your code goes here
    }
  }

  class Mace : Weapon
  {
    public Mace(Game game, Point location)
      : base(game, location) { }
    public override string Name { get { return "Sword"; } }
    public override void Attack(Direction direction, Random random)
    {
      // Your code goes here
    }
  }


  
}
