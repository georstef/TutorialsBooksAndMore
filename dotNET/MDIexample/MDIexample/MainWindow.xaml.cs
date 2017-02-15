using System.Windows;

namespace MDIexample
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

        private void button_Click(object sender, RoutedEventArgs e)
        {


            //DockingManager dm = (DockingManager)this.Parent;


            //Window1 mdiChild = new Window1();
            //dm.Children.Add(mdiChild);
            //mdiChild.Show();
            //DockingManager dm = (DockingManager)this.Parent;
            ////Window1 w = dm.CreateMDIChild<Window1>();
            //Window1 mdiChild = new Window1();
            //DocumentContainer.SetMDIBounds(mdiChild, new Rect(10, 10, 600, 600));
            //DockingManager.SetState(mdiChild, DockState.Document);
            //dm.Children.Add(mdiChild);
            //mdiChild.BringIntoView();

        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            dmnMDIPanel.CreateMDIChild<Window1>();
            //Window1 mdiChild = new Window1();
            //mdiChild.Show();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            dmnMDIPanel.CreateMDIChild<Window2>();
        }
    }
}
