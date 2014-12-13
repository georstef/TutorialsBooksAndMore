using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _12_lab2_the_quest
{
  enum Direction  {Up, Right, Down, Left }
  public partial class Form1 : Form
  {
    private Game game;
    private Random random = new Random();

    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      game = new Game(new Rectangle(78, 57, 420, 155));
      game.NewLevel(random);
      UpdateCharacters();
    }

    private void UpdateCharacters()
    {
      imgPlayer.Location = game.PlayerLocation;
      edtPlayerHitPoints.Text = game.PlayerHitPoints.ToString();
      bool showBat = false;
      bool showGhost = false;
      bool showGhoul = false;
      int enemiesShown = 0;
      //plus more stuff here

      foreach (Enemy enemy in game.Enemies)
      {
        if (enemy is Bat)
        {
          imgBat.Location = enemy.Location;
          edtBatHitPoints.Text = enemy.HitPoints.ToString();
          if (enemy.HitPoints > 0)
          {
            showBat = true;
            enemiesShown++;
          }
        }

        if (enemy is Ghost)
        {
          imgGhost.Location = enemy.Location;
          edtGhostHitPoints.Text = enemy.HitPoints.ToString();
          if (enemy.HitPoints > 0)
          {
            showGhost = true;
            enemiesShown++;
          }
        }

        if (enemy is Ghoul)
        {
          imgGhoul.Location = enemy.Location;
          edtGhoulHitPoints.Text = enemy.HitPoints.ToString();
          if (enemy.HitPoints > 0)
          {
            showGhoul = true;
            enemiesShown++;
          }
        }
      }


      imgSword.Visible = false;
      imgBow.Visible = false;
      imgMace.Visible = false;
      imgPotionRed.Visible = false;
      imgPotionBlue.Visible = false;
      Control weaponControl = null;
      switch (game.WeaponInRoom.Name) {
        case "Sword":
          weaponControl = imgSword; 
          break;
        case "Bow":
          weaponControl = imgBow; 
          break;
        case "Mace":
          weaponControl = imgMace; 
          break;
      }


      weaponControl.Location = game.WeaponInRoom.Location;
      if (game.WeaponInRoom.PickedUp)
        weaponControl.Visible = false;
      else
        weaponControl.Visible = true;

      if (game.PlayerHitPoints <= 0) {
        MessageBox.Show("You died");
        Application.Exit();
      }

      if (enemiesShown < 1) {
        MessageBox.Show("You have defeated the enemies on this level");
        game.NewLevel(random);
        UpdateCharacters();
      }
    }//updatecharacters
  }
}
