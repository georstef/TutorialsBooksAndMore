using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace TestXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadXML("TestXML.xml");

        }

        private void btnLoad_Click(object sender, System.EventArgs e)
        {
            LoadXML("TestXML.xml");
        }

        private void LoadXML(string Filename)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@Filename);

            XmlNodeList nodes = doc.DocumentElement.SelectNodes("/PARTS/PART");

            BindingList<Part> parts = new BindingList<Part>();

            foreach (XmlNode node in nodes)
            {
                Part part = new Part();

                part.item = node.SelectSingleNode("ITEM").InnerText;
                part.manufacturer = node.SelectSingleNode("MANUFACTURER").InnerText;
                part.model = node.SelectSingleNode("MODEL").InnerText;
                part.cost = double.Parse(node.SelectSingleNode("COST").InnerText);

                parts.Add(part);
            }

            bsTestXML.DataSource = parts;
        }


        private void btnRaise_Click(object sender, System.EventArgs e)
        {
            var parts = (BindingList<Part>)bsTestXML.DataSource;
            foreach (var part in parts)
            {
                part.percentAdd += 10;
            }
            View1.RefreshData();
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            var parts = (BindingList<Part>)bsTestXML.DataSource;
            foreach (var part in parts)
            {
                part.percentAdd -= 10;
            }
            View1.RefreshData();
        }
    }
    public class Part
    {
        public double _percentAdd;

        public string item { get; set; }
        public string manufacturer { get; set; }
        public string model { get; set; }
        public double cost { get; set; }
        public double percentAdd
        {
            get { return _percentAdd; }
            set
            {
                _percentAdd = value;
                newCost = Math.Round(cost * (1 + (_percentAdd / 100)), 2, MidpointRounding.AwayFromZero);
                diff = Math.Round(newCost - cost, 2, MidpointRounding.AwayFromZero);
            }
        }
        public double newCost { get; set; }

        public double diff { get; set; }
    }
}

/* EXAMPLE
 
<?xml version="1.0"?>
<!DOCTYPE PARTS SYSTEM "parts.dtd">
<?xml-stylesheet type="text/css" href="xmlpartsstyle.css"?>
<PARTS>
   <TITLE>Computer Parts</TITLE>
   <PART>
      <ITEM>Motherboard</ITEM>
      <MANUFACTURER>ASUS</MANUFACTURER>
      <MODEL>P3B-F</MODEL>
      <COST>123.00</COST>
   </PART>
   <PART>
      <ITEM>Video Card</ITEM>
      <MANUFACTURER>ATI</MANUFACTURER>
      <MODEL>All-in-Wonder Pro</MODEL>
      <COST>160.00</COST>
   </PART>
   <PART>
      <ITEM>Sound Card</ITEM>
      <MANUFACTURER>Creative Labs</MANUFACTURER>
      <MODEL>Sound Blaster Live</MODEL>
      <COST>80.00</COST>
   </PART>
   <PART>
      <ITEM? inch Monitor</ITEM>
      <MANUFACTURER>LG Electronics</MANUFACTURER>
      <MODEL> 995E</MODEL>
      <COST>290.00</COST>
   </PART>
</PARTS> 
 */
