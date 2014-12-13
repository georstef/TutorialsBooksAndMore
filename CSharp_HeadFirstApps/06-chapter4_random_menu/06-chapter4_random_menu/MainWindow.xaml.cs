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
using System.Windows.Threading;

namespace _06_chapter4_random_menu
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    DispatcherTimer timer = new DispatcherTimer() {Interval = TimeSpan.FromMilliseconds(800)};
    Random random = new Random();
    Stats stats = new Stats();

    public MainWindow()
    {
      InitializeComponent();

    }

    private void btnCreateMenu_Click(object sender, RoutedEventArgs e)
    {
      MenuMaker item = new MenuMaker(){Randomizer = new Random()};
      edtMenu.Text += '\n' + item.GetMenuItem();
    }

    private void btnStartTyping_Click(object sender, RoutedEventArgs e)
    {
      timer.Tick += timer_Tick;
      timer.Start();
    }

    void timer_Tick(object sender, EventArgs e)
    {
      // Add a random key to the ListBox
      edtTypingBox.Items.Add((Key)random.Next(65, 90));
      if (edtTypingBox.Items.Count > 700)
      {
        edtTypingBox.Items.Clear();
        edtTypingBox.Items.Add("Game over");
        timer.Stop();
      }
 
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      // If the user pressed a key that's in the ListBox, remove it
      // and then make the game a little faster
      if (edtTypingBox.Items.Contains(e.Key))
      {
        edtTypingBox.Items.Remove(e.Key);
        //edtTypingBox.Refresh();
        if (timer.Interval.Milliseconds > 400)
          timer.Interval = TimeSpan.FromMilliseconds(timer.Interval.Milliseconds - 10);
        if (timer.Interval.Milliseconds > 250)
          timer.Interval = TimeSpan.FromMilliseconds(timer.Interval.Milliseconds - 7);
        if (timer.Interval.Milliseconds > 100)
          timer.Interval = TimeSpan.FromMilliseconds(timer.Interval.Milliseconds - 2);
        progressBar.Value = 800 - timer.Interval.Milliseconds;
        // The user pressed a correct key, so update the Stats object
        // by calling its Update() method with the argument true
        stats.Update(true);
      }
      else
      {
        // The user pressed an incorrect key, so update the Stats object
        // by calling its Update() method with the argument false
        stats.Update(false);
      }
      lblScore.Text = "Correct: " + stats.Correct + "  Missed: " + stats.Missed + "  Total: " + stats.Total + "  Accuracy: " + stats.Accuracy + "%";
    }
  }
}
