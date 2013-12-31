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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _11_chapter9_serialization
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    Random random = new Random();

    public MainWindow()
    {
      InitializeComponent();
    }

    private Deck RandomDeck(int number)
    {
      Deck myDeck = new Deck(false);
      for (int i = 0; i < number; i++)
      {
        myDeck.AddCard(
          new Card(
              (Suits)random.Next(4),
              (Values)random.Next(1, 14)
          )
        );
      }

      return myDeck;
    }

    private void DealCards(Deck deckToDeal, string title, ListBox l)
    {
      l.Items.Add("------------------");
      l.Items.Add(title);
      l.Items.Add("------------------");
      while (deckToDeal.cards.Count > 0)
      {
        l.Items.Add(deckToDeal.cards[0]);
        deckToDeal.cards.RemoveAt(0);
      }
      
    }

    private void btnSerializeDeck_Click(object sender, RoutedEventArgs e)
    {
      Deck deckToWrite = RandomDeck(5);
      using (Stream output = File.Create("Deck1.dat"))
      {
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(output, deckToWrite);
      }
      DealCards(deckToWrite, "Wrote to the file", edtDeck1);
    }

    private void btnDeserializeDeck_Click(object sender, RoutedEventArgs e)
    {
      using (Stream input = File.OpenRead("Deck1.dat"))
      {
        BinaryFormatter bf = new BinaryFormatter();
        Deck deckFromFile = (Deck)bf.Deserialize(input);
        DealCards(deckFromFile, "Read from the file", edtDeck2);
      }
    }

    private void btnSerializeManyDecks_Click(object sender, RoutedEventArgs e)
    {
      using (Stream output = File.Create("Deck2.dat"))
      {
        BinaryFormatter bf = new BinaryFormatter();
        for (int i = 1; i <= 3; i++)
        {
          Deck deckToWrite = RandomDeck(random.Next(1, 4));
          bf.Serialize(output, deckToWrite);
          DealCards(deckToWrite, "Write Deck #" + i, edtDeck1);
        }
      }
    }

    private void btnDeserializeManyDecks_Click(object sender, RoutedEventArgs e)
    {
      using (Stream input = File.OpenRead("Deck2.dat"))
      {
        BinaryFormatter bf = new BinaryFormatter();

        //example of deserializing an unknown number if objects (with 'while loop' not 'for loop')
        while (input.Position < input.Length)
        {
          Deck deckToRead = (Deck)bf.Deserialize(input);
          DealCards(deckToRead, "Deck read", edtDeck2);
        }
      }
    }
  }
}
