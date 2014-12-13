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

namespace _08_chapter6_inheritance_beehive
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Queen queen;
    public MainWindow()
    {
      InitializeComponent();
      Worker[] workers = new Worker[4];
      workers[0] = new Worker(new string[] { "Nectar collector", "Honey manufacturing" });
      workers[1] = new Worker(new string[] { "Egg care", "Baby bee tutoring" });
      workers[2] = new Worker(new string[] { "Hive maintenance", "Sting patrol" });
      workers[3] = new Worker(new string[] { "Nectar collector", "Honey manufacturing", "Egg care", "Baby bee tutoring", "Hive maintenance", "Sting patrol" });
      queen = new Queen(workers);
    }

    private void btnAssign_Click(object sender, RoutedEventArgs e)
    {
      if (queen.AssignWork(edtJob.Text, int.Parse(edtShift.Text)))
      {
        MessageBox.Show(string.Format("{0} assigned.", edtJob.Text));
      }
      else
      {
        MessageBox.Show(string.Format("{0} could not be assigned.", edtJob.Text));
      }
    }

    private void btnEndShift_Click(object sender, RoutedEventArgs e)
    {
      edtReport.Text = queen.NextShift();
    }


  }
}
