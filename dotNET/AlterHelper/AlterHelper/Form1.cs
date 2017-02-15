using System.Resources;
using System.Windows.Forms;

namespace AlterHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            openFolder.SelectedPath = edtFolder.Text;
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                edtFolder.Text = openFolder.SelectedPath;
            }

            //openFile.InitialDirectory = edtFolder.Text;
            //if (openFile.ShowDialog() == DialogResult.OK)
            //{
            //    edtFolder.Text = openFile.FileName;
            //}
        }


        public static void AddOrUpdateResource(string resourceFilepath, string newKey, string newValue)
        {
            string resourcesFile = resourceFilepath + @"\Resources.resx";
            var reader = new ResXResourceReader(resourcesFile);//same fileName
            reader.BasePath = resourceFilepath;// this is very important
            var node = reader.GetEnumerator();

            var writer = new ResXResourceWriter(resourcesFile);//same fileName(not new)
            while (node.MoveNext())
            {
                string nodeKey = node.Key.ToString();
                string nodeValue = node.Value.ToString();
                if (nodeKey == "alter")
                {
                    nodeValue += "\r\n" + newKey;//add new script name
                }
                writer.AddResource(nodeKey, nodeValue);
            }
            var newNode = new ResXDataNode(newKey, newValue);
            writer.AddResource(newNode);
            writer.Generate();
            writer.Close();
        }

        //public static void AddOrUpdateResource(string resourceFilepath, string key, string value)
        //{
        //    string resourcesFile = resourceFilepath + @"\Resources.resx";

        //    var resx = new List<DictionaryEntry>();
        //    using (var reader = new ResXResourceReader(resourcesFile))
        //    {
        //        reader.BasePath = resourceFilepath;// this is very important
        //        resx = reader.Cast<DictionaryEntry>().ToList();
        //        var existingResource = resx.Where(r => r.Key.ToString() == key).FirstOrDefault();
        //        if (existingResource.Key == null && existingResource.Value == null) // NEW!
        //        {
        //            resx.Add(new DictionaryEntry() { Key = key, Value = value });
        //        }
        //        else // MODIFIED RESOURCE!
        //        {
        //            var modifiedResx = new DictionaryEntry() { Key = existingResource.Key, Value = value };
        //            resx.Remove(existingResource);  // REMOVING RESOURCE!
        //            resx.Add(modifiedResx);  // AND THEN ADDING RESOURCE!
        //        }
        //    }
        //    using (var writer = new ResXResourceWriter(resourcesFile))
        //    {
        //        resx.ForEach(r =>
        //        {
        //            // Again Adding all resource to generate with final items
        //            writer.AddResource(r.Key.ToString(), r.Value.ToString());
        //        });
        //        writer.Generate();
        //    }
        //}

        private void btnAlter_Click(object sender, System.EventArgs e)
        {
            AddOrUpdateResource(edtFolder.Text, "stratos2", "long long sql script");

            //string filename = edtFolder.Text + "\\Resources.resx";
            //ResXResourceReader rr = new ResXResourceReader(filename);
            //rr.BasePath = edtFolder.Text;// this is very important
            //IDictionaryEnumerator dict = rr.GetEnumerator();
            //while (dict.MoveNext())
            //{
            //    edtMemo.Text += dict.Key.ToString() + dict.Value.ToString();
            //}
        }

        //    public static void UpdateResourceFile(Hashtable data, string path)
        //    {
        //        Hashtable resourceEntries = new Hashtable();

        //        //Get existing resources
        //        ResXResourceReader reader = new ResXResourceReader(path);
        //        if (reader != null)
        //        {
        //            IDictionaryEnumerator id = reader.GetEnumerator();
        //            foreach (DictionaryEntry d in reader)
        //            {
        //                if (d.Value == null)
        //                    resourceEntries.Add(d.Key.ToString(), "");
        //                else
        //                    resourceEntries.Add(d.Key.ToString(), d.Value.ToString());
        //            }
        //            reader.Close();
        //        }

        //        //Modify resources here...
        //        foreach (string key in data.Keys)
        //        {
        //            if (!resourceEntries.ContainsKey(key))
        //            {

        //                string value = data[key].ToString();
        //                if (value == null) value = "";

        //                resourceEntries.Add(key, value);
        //            }
        //        }

        //        //Write the combined resource file
        //        ResXResourceWriter resourceWriter = new ResXResourceWriter(path);

        //        foreach (string key in resourceEntries.Keys)
        //        {
        //            resourceWriter.AddResource(key, resourceEntries[key]);
        //        }
        //        resourceWriter.Generate();
        //        resourceWriter.Close();

        //    }
    }
}