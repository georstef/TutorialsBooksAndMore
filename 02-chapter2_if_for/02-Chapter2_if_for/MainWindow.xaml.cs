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

namespace _02_Chapter2_if_for
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
      string name = "george s.";
      
      int x = 3 * 17;
      double d = Math.PI / 2;
      myLabel.Text = String.Format("name = {0}\nx = {1}\npi/2 = {2}", name,x,d);
    }

    private void button2_Click(object sender, RoutedEventArgs e)
    {
      int x = 5;
      if (x == 10)
      {
        myLabel.Text = "x is 10";
      }
      else
      {
        myLabel.Text = "x is NOT 10";
      }
    }

    private void button3_Click(object sender, RoutedEventArgs e)
    {
      int someValue = 100;
      string name = "george";
      if ((someValue == 100) && (name == "george"))
      {
        myLabel.Text = "x is 100 and the name is george";
      }
      myLabel.Text += "\nthis line always runs";
    }

    private void button4_Click(object sender, RoutedEventArgs e)
    {
      int count = 0;
      while (count < 10)
      {
        count = count + 1;
      }
      //at this point count is 10

      for (int i = 0; i < 4; i++)
      {
        count = count - 1;
      }
      //at this point count is 6 (10-4)
      myLabel.Text = "The answer is " + count;
    }
  }
}
