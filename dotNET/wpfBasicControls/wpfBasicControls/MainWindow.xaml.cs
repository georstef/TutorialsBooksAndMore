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

namespace wpfBasicControls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            TextBlock tb = new TextBlock();
            tb.TextWrapping = TextWrapping.Wrap;
            tb.Margin = new Thickness(10);
            tb.Inlines.Add("An example on ");
            tb.Inlines.Add(new Run("the TextBlock control ") { FontWeight = FontWeights.Bold });
            tb.Inlines.Add("using ");
            tb.Inlines.Add(new Run("inline ") { FontStyle = FontStyles.Italic });
            tb.Inlines.Add(new Run("text formatting ") { Foreground = Brushes.Blue });
            tb.Inlines.Add("from ");
            tb.Inlines.Add(new Run("Code-Behind") { TextDecorations = TextDecorations.Underline });
            tb.Inlines.Add(".");
            sPanel.Children.Add(tb);
            //this.Content = tb;
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            txtStatus.Text = "Selection starts at character #" + textBox.SelectionStart + Environment.NewLine;
            txtStatus.Text += "Selection is " + textBox.SelectionLength + " character(s) long" + Environment.NewLine;
            txtStatus.Text += "Selected text: '" + textBox.SelectedText + "'";
        }

        private void cbAllFeatures_CheckedChanged(object sender, RoutedEventArgs e)
        {
            bool newVal = (cbAllFeatures.IsChecked == true);
            cbFeatureAbc.IsChecked = newVal;
            cbFeatureXyz.IsChecked = newVal;
            cbFeatureWww.IsChecked = newVal;
        }

        private void cbFeature_CheckedChanged(object sender, RoutedEventArgs e)
        {
            cbAllFeatures.IsChecked = null;
            if ((cbFeatureAbc.IsChecked == true) && (cbFeatureXyz.IsChecked == true) && (cbFeatureWww.IsChecked == true))
                cbAllFeatures.IsChecked = true;
            if ((cbFeatureAbc.IsChecked == false) && (cbFeatureXyz.IsChecked == false) && (cbFeatureWww.IsChecked == false))
                cbAllFeatures.IsChecked = false;
        }

        private void edtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(edtPassword.Password);
        }
    }
}
