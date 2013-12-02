using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _03_Chapter2_winforms
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      while (Visible)
      {
        for (int i = 0; i < 254 && Visible; i++)
        {
          BackColor = Color.FromArgb(i, 255 - i, i);
          Application.DoEvents(); //
          //System.Threading.Thread.Sleep(1);
        }

        for (int i = 254; i >= 0 && Visible; i--)
        {
          this.BackColor = Color.FromArgb(i, 255 - i, i);
          Application.DoEvents(); //
          //System.Threading.Thread.Sleep(1);
        }
      }
    }

    private void btnTalker_Click(object sender, EventArgs e)
    {
      Talker.BlahBlahBlah("Click ok!!!", 5);
    }
  }
}
