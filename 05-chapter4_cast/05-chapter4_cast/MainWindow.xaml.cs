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
using System.Windows.Forms;

namespace _05_chapter4_cast
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

    private void btnCast_Click(object sender, RoutedEventArgs e)
    {
      int myInt = 10;
      byte myByte = (byte)myInt;
      double myDouble = (double)myByte;
      //bool myBool = (bool)myDouble;
      string myString = "false";
      //bool myBool = (bool)myString;
      
      //myString = (string)myInt;
      myString = myInt.ToString();
      
      myString = myInt.ToString();
      //bool myBool = (bool)myByte;
      bool myBool = true;
      //myByte = (byte)myBool;
      short myShort = (short)myInt;
      char myChar = 'x';
      
      //myString = (string)myChar;
      myString = myChar.ToString();

      long myLong = (long)myInt;
      decimal myDecimal = (decimal)myLong;
      myString = myString + myInt + myByte + myDouble + myChar;

      //MessageBox.Show("text", "caption");
      //MessageBox.Show("text", "caption", MessageBoxButton.OKCancel);
      //MessageBox.Show("text", "caption", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
      //MessageBox.Show("text", "caption", MessageBoxButton.YesNoCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel);
      if (System.Windows.MessageBox.Show("Close the application?", "caption", MessageBoxButton.YesNo, MessageBoxImage.Exclamation, MessageBoxResult.No) == MessageBoxResult.Yes)
      {
        Close();      
      }
    }
  }
}
