using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace resourceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open+show alter.txt
            edtMemo.Text = Properties.Resources.alter.ToString();

            //show *.sql files
            foreach (var item in edtMemo.Lines)
            {
                edtMemo.Text += "\r\n" + Properties.Resources.ResourceManager.GetString(item.ToString()).ToString();
            }
        }

        private string OpenResource(string resName)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resourceName = assembly.GetName().Name + "." + resName;

                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            catch
            {
                return "Error accessing resources!";
            }
        }

    }
}
