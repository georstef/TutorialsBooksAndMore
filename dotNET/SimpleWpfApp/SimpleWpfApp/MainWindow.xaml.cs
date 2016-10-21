using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleWpfApp
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

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            //local resource
            btnClickMe.Content = this.FindResource("strWindow").ToString(); //ToString() is not needed because it's a string resource
        }

        private void btnClickMe2_Click(object sender, RoutedEventArgs e)
        {
            //application resource
            btnClickMe2.Content = Application.Current.FindResource("strApp");

            //this will work too since FindResource goes up the hierarchy to find the resource
            btnClickMe2.Content = this.FindResource("strApp").ToString(); 
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string s = null;
            try
            {
                s.Trim();
            }
            catch (Exception ex)
            {
                //this error is caught by us
                MessageBox.Show("Our try except: "+ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            //this error is caught by the App.xaml [DispatcherUnhandledException]
            s.Trim();
        }
    }
}
