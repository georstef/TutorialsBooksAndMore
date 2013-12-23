using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace _07_lab1_racetrack
{
  class Dog
  {
    public string lane;
    public Image imgDog;
    public int currentPosition;//the left part
    int width;

    public Dog(string laneIn, Image imgDogIn, int widthIn, int initialPosition)
    {
      lane = laneIn;
      imgDog = imgDogIn;
      width = widthIn;
      setPosition(initialPosition);
    }

    public void Move(int steps)
    {
      currentPosition += steps;
      changePosition();
    }

    public bool hasFinished(int finishLine)
    {
      return (currentPosition+width >= finishLine);
    }

    public void setPosition(int position)
    {
      currentPosition = position;
      changePosition();
    }

    private void changePosition()
    {
      Canvas.SetLeft(imgDog, currentPosition);
    }

  }
}
