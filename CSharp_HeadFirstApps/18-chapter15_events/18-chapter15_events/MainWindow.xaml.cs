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
using System.Collections.ObjectModel;

namespace _18_chapter15_events
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    BaseballSimulator baseballSimulator;
    public MainWindow()
    {
      InitializeComponent();
      baseballSimulator = FindResource("baseballSimulator") as BaseballSimulator;
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      baseballSimulator.PlayBall();
    }
  }

  class Ball
  {
    public event EventHandler BallInPlay;
    public void OnBallInPlay(BallEventArgs e)
    {
      EventHandler ballInPlay = BallInPlay;
      if (ballInPlay != null)
        ballInPlay(this, e);
    }
  }

  class BallEventArgs : EventArgs
  {
    public int Trajectory { get; private set; }
    public int Distance { get; private set; }
    public BallEventArgs(int trajectory, int distance)
    {
      this.Trajectory = trajectory;
      this.Distance = distance;
    }
  }
  
  class Pitcher {
    public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();
    private int pitchNumber = 0;
    public Pitcher(Ball ball) {
      ball.BallInPlay += ball_BallInPlay;
    }

    void ball_BallInPlay(object sender, EventArgs e) {
      pitchNumber++;
      if (e is BallEventArgs) {
        BallEventArgs ballEventArgs = e as BallEventArgs;
        if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
          CatchBall();
        else
          CoverFirstBase();
      }
    }

    private void CatchBall() {
      PitcherSays.Add("Pitch #" + pitchNumber + ": I caught the ball");
    }

    private void CoverFirstBase() {
      PitcherSays.Add("Pitch #" + pitchNumber + ": I covered first base");
    }
  }

    class Fan
    {
      public ObservableCollection<string> FanSays = new ObservableCollection<string>();
      private int pitchNumber = 0;
      public Fan(Ball ball)
      {
        ball.BallInPlay += new EventHandler(ball_BallInPlay);
      }

      void ball_BallInPlay(object sender, EventArgs e)
      {
        pitchNumber++;
        if (e is BallEventArgs)
        {
          BallEventArgs ballEventArgs = e as BallEventArgs;
          if (ballEventArgs.Distance > 400 && ballEventArgs.Trajectory > 30)
            FanSays.Add("Pitch #" + pitchNumber
            + ": Home run! I'm going for the ball!");
          else
            FanSays.Add("Pitch #" + pitchNumber + ": Woo-hoo! Yeah!");
        }
      }
    }

    class BaseballSimulator
    {
      private Ball ball = new Ball();
      private Pitcher pitcher;
      private Fan fan;
      public ObservableCollection<string> FanSays { get { return fan.FanSays; } }
      public ObservableCollection<string> PitcherSays { get { return pitcher.PitcherSays; } }
      public int Trajectory { get; set; }
      public int Distance { get; set; }
      public BaseballSimulator()
      {
        pitcher = new Pitcher(ball);
        fan = new Fan(ball);
      }
      public void PlayBall()
      {
        BallEventArgs ballEventArgs = new BallEventArgs(Trajectory, Distance);
        ball.OnBallInPlay(ballEventArgs);
      }
    }

}
