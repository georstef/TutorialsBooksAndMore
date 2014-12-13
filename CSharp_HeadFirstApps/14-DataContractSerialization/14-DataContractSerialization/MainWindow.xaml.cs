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
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.IO;
using MyNamespace;

namespace _14_DataContractSerialization
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    string FILENAME = "DataContractSerializer.txt";
    string FILENAME_XML = "DataContractSerializerXML.txt";
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnSerialize_Click(object sender, RoutedEventArgs e)
    {
      //instantiate the Guy object
      Guy guy = new Guy(edtName.Text, Convert.ToInt32(edtCash.Text));

      DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));

      using (Stream the_file = File.Create(FILENAME))
      {
        serializer.WriteObject(the_file, guy);
      }
      
      //---------------------------------------------------------
      /* cannot be serialized because [Guy] does not have a parameterless constructor.
       * 
      XmlSerializer xml_serializer = new XmlSerializer(typeof(Guy));

      using (Stream the_file = File.Create(FILENAME))
      {
        xml_serializer.Serialize(the_file, guy);
      }
       * */
      
      //---------------------------------------------------------
      ShowFilename(FILENAME, edtFileData);
      //ShowFilename(FILENAME_XML, edtFileDataXML);
    }
     
    private void btnDeserialize_Click(object sender, RoutedEventArgs e)
    {
      Guy guy;
      DataContractSerializer serializer = new DataContractSerializer(typeof(Guy));
      using (Stream the_file = File.OpenRead(FILENAME))
      {
        guy = serializer.ReadObject(the_file) as Guy;
      }
      edtNameDeserialized.Text = guy.name;
      edtCashDeserialized.Text = guy.cash.ToString();
    }

    private void ShowFilename(string filename, TextBlock tb)
    {
      string lines;
      using (StreamReader reader = new StreamReader(filename))
      {
        //throw new Exception();
        lines = reader.ReadLine();
      }
      tb.Text = lines;
    }
  }
}
