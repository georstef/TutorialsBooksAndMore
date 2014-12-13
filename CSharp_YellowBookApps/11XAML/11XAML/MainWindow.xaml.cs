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

namespace _11XAML
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

    private void equalsButton_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        resultTextBlock.Text = (float.Parse(firstNumberTextBox.Text) + float.Parse(secondNumberTextBox.Text)).ToString();
      }
      catch 
      {
        MessageBox.Show("Invalid number", "Adding machine");
      }
    }
  }
}
