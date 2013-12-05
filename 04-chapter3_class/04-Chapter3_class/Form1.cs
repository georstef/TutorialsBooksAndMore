using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _04_Chapter3_class
{
  public partial class Form1 : Form
  {
    Guy Joe = new Guy("Joe", 100);
    Guy Bob = new Guy("Bob", 50);

    
    public Form1()
    {
      InitializeComponent();
      RefreshLabels();
    }

    private void btnGiveToBob_Click(object sender, EventArgs e)
    {
      if (Joe.GiveCash(int.Parse(edtGiveToBob.Text)))
      {
        Bob.GetCash(int.Parse(edtGiveToBob.Text));
      }
      RefreshLabels();
    }

    private void btnGiveToJoe_Click(object sender, EventArgs e)
    {
      if (Bob.GiveCash(int.Parse(edtGiveToJoe.Text)))
      {
        Joe.GetCash(int.Parse(edtGiveToJoe.Text));
      }
      RefreshLabels();
    }

    private void RefreshLabels() 
    {
      Joe.RefreshLabel(lblJoeCash);
      Bob.RefreshLabel(lblBobCash);
    }
  }
}
