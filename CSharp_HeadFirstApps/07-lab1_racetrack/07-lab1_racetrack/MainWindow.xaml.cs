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

namespace _07_lab1_racetrack
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Guys[] guys = new Guys[3];
    Dog[] dogs = new Dog[4];
    int dogLeft;
    int dogWidth;
    Random random = new Random();
    DispatcherTimer timer = new DispatcherTimer() { Interval = TimeSpan.FromMilliseconds(5)};
    
    public MainWindow()
    {
      InitializeComponent();

      guys[0] = new Guys("Joe", 100);
      guys[1] = new Guys("Bob", 85);
      guys[2] = new Guys("Jim", 66);

      refreshRadioButtons();

      dogLeft = (int)Canvas.GetLeft(imgDog1);
      dogWidth = (int)imgDog1.Width;

      dogs[0] = new Dog("1", imgDog1, dogWidth, dogLeft);
      dogs[1] = new Dog("2", imgDog2, dogWidth, dogLeft);
      dogs[2] = new Dog("3", imgDog3, dogWidth, dogLeft);
      dogs[3] = new Dog("4", imgDog4, dogWidth, dogLeft);

      timer.Tick += timer_Tick;
    }

    private void refreshRadioButtons()
    {
      edtPlayer1.Content = guys[0].getName();
      edtPlayer2.Content = guys[1].getName();
      edtPlayer3.Content = guys[2].getName();
    }

    private int getGuySelected()
    {
      if (edtPlayer1.IsChecked == true)
      {
        return 0;
      }
      else if (edtPlayer2.IsChecked == true)
      {
        return 1;
      }
      else {
        return 2;
      }
    }

    private void fillBetFields(Guys guy)
    {
      if (guy.bet != null)
      {
        edtBetDog.Text = guy.bet.dog.lane;
        edtBetCash.Text = guy.bet.money.ToString();
      }
      else
      {
        edtBetDog.Text = "";
        edtBetCash.Text = "";
      }
    }

    private void edtPlayer1_Click(object sender, RoutedEventArgs e)
    {
      fillBetFields(guys[getGuySelected()]);
    }

    private void edtPlayer2_Click(object sender, RoutedEventArgs e)
    {
      fillBetFields(guys[getGuySelected()]);
    }

    private void edtPlayer3_Click(object sender, RoutedEventArgs e)
    {
      fillBetFields(guys[getGuySelected()]);
    }

    private void placeBet(Guys guy)
    {
      int dogSelected = Convert.ToInt32(edtBetDog.Text);
      int betSelected = Convert.ToInt32(edtBetCash.Text);

      if ((dogSelected >= 1) && (dogSelected <= 4) && (betSelected >= 0) && (guy.cashRepository(betSelected)))
      {
        guy.bet = new Bet();
        guy.bet.dog = dogs[dogSelected-1];
        guy.bet.money = betSelected;
      }
      else 
      {
        MessageBox.Show("Bet not valid.");
      }

    }

    private void btnBet_Click(object sender, RoutedEventArgs e)
    {
      placeBet(guys[getGuySelected()]);

      showBets();
    }

    void showBets()
    {
      edtBets.Text = guys[0].getBet() + '\n' + guys[1].getBet() + '\n' + guys[2].getBet();
    }
  
    void timer_Tick(object sender, EventArgs e)
    { 
      for (int i = 0; i < 4; i++)
      {
        dogs[i].Move(random.Next(4) + 1);

        if (dogs[i].hasFinished((int)runArea.ActualWidth))
        {
          timer.Stop();
          MessageBox.Show(string.Format("Winner is dog No {0}", i + 1));
          for (int j = 0; j < 3; j++)
          {
            guys[j].checkBet(dogs[i]);
          }
          refreshRadioButtons();
          resetDogs();
          break;
        }
      }
    }

    private void resetDogs()
    {
      for (int i = 0; i < 4; i++)
      {
       dogs[i].setPosition(dogLeft);
      }    
    }

    private void btnRace_Click(object sender, RoutedEventArgs e)
    {
      showBets();

      timer.Start();
    }
  }
}
