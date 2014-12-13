using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _04_Chapter3_class
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new Form1());
    }
  }

  class Guy {
    public string name = "";
    public int cash = 0;

    public Guy(string name, int cash) {
      this.name = name;
      this.cash = cash;    
    }

    public void GetCash(int money)
    {
      this.cash += money;
    }

    public bool GiveCash(int money)
    {
      if (money <= this.cash)
      {
        this.cash -= money;
        return true;
      }
      else 
      {
        MessageBox.Show("Not enough money");
        return false;
      }
    }

    public void RefreshLabel(Label label)
    { 
      label.Text = this.cash.ToString();
    }
  
  }
}
