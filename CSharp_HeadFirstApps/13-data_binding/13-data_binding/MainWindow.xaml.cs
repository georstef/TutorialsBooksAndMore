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
using System.ComponentModel;

namespace _13_data_binding
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  /// 
  public partial class MainWindow : Window
  {
    Person _person;

    public MainWindow()
    {
      InitializeComponent();
      //ManuallyMoveData(); //version #1
      //BindInCode(); //version #2 (wtf???)
      BindInXaml();
    }

    //----------------------------
    //#1
    //----------------------------
    private void ManuallyMoveData()
    {
      _person = new Person
      {
        FirstName = "John",
        LastName = "Smith"
      };

      this.edtFirstName.Text = _person.FirstName;
      this.edtLastName.Text = _person.LastName;
      this.lblFullName.Text = _person.FullName;

      this.edtFirstName.TextChanged += edtFirstName_TextChanged;
      this.edtLastName.TextChanged += edtLastName_TextChanged;
    }

    private void edtFirstName_TextChanged(object sender, TextChangedEventArgs e)
    {
      _person.FirstName = this.edtFirstName.Text;
      this.lblFullName.Text = _person.FullName;
    }

    private void edtLastName_TextChanged(object sender, TextChangedEventArgs e)
    {
      _person.LastName = this.edtLastName.Text;
      this.lblFullName.Text = _person.FullName;
    }
    /* 
    //#1 Person Class
    public class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }

      public string FullName
      {
        get
        {
          return String.Format("{0}, {1}",
              this.LastName, this.FirstName);
        }
      }
    }
    */

    //----------------------------
    //#2
    //----------------------------
    private void BindInCode()
    {
      var person = new Person
      {
        FirstName = "Peter",
        LastName = "Smith"
      };

      Binding b = new Binding();
      b.Source = person;
      b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
      b.Path = new PropertyPath("FirstName");
      this.edtFirstName.SetBinding(TextBox.TextProperty, b);

      b = new Binding();
      b.Source = person;
      b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
      b.Path = new PropertyPath("LastName");
      this.edtLastName.SetBinding(TextBox.TextProperty, b);

      b = new Binding();
      b.Source = person;
      b.Path = new PropertyPath("FullName");
      this.lblFullName.SetBinding(TextBlock.TextProperty, b);
    }

    //----------------------------
    //#3
    //----------------------------
    private void BindInXaml()
    {
      base.DataContext = new Person
      {
        FirstName = "Alan",
        LastName = "Smith"
      };
    }
  }


  //#2 & #3 Person Class (with event????)
  public class Person : INotifyPropertyChanged
  {
    string _firstName;
    string _lastName;

    public string FirstName
    {
      get { return _firstName; }
      set
      {
        _firstName = value;
        this.OnPropertyChanged("FirstName");
        this.OnPropertyChanged("FullName");
      }
    }

    public string LastName
    {
      get { return _lastName; }
      set
      {
        _lastName = value;
        this.OnPropertyChanged("LastName");
        this.OnPropertyChanged("FullName");
      }
    }

    public string FullName
    {
      get
      {
        return String.Format("{0}, {1}",
            this.LastName, this.FirstName);
      }
    }

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string propName)
    {
      if (this.PropertyChanged != null)
      {
        this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
      }
    }

    #endregion
  }

}
