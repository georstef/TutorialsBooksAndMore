using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace ParsingXML_HTML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnParse1_Click(object sender, System.EventArgs e)
        {
            //ParseWithHtmlDocument(edtProduct1.Text);
            edtLowestPrice1.Text = GetLowetPrice(edtProduct1.Text).ToString();
            edtDiff1.Text = (double.Parse(edtPrice1.Text) - double.Parse(edtLowestPrice1.Text)).ToString();
            edtPercentDiff1.Text = (Math.Round(
                (double.Parse(edtDiff1.Text) * 100) / double.Parse(edtLowestPrice1.Text),
                2,
                MidpointRounding.AwayFromZero)).ToString() + " %";
        }

        private void btnParse2_Click(object sender, System.EventArgs e)
        {
            //ParseWithHtmlDocument(edtProduct2.Text);
            edtLowestPrice2.Text = GetLowetPrice(edtProduct2.Text).ToString();
            edtDiff2.Text = (double.Parse(edtPrice2.Text) - double.Parse(edtLowestPrice2.Text)).ToString();
            edtPercentDiff2.Text = (Math.Round(
                (double.Parse(edtDiff2.Text) * 100) / double.Parse(edtLowestPrice2.Text),
                2,
                MidpointRounding.AwayFromZero)).ToString() + " %";
        }


        private double GetLowetPrice(string productName)
        {
            string html;
            productName = productName.Replace(" ", "+");
            // obtain some arbitrary html....
            using (var client = new WebClient())
            {
                html = client.DownloadString("http://www.skroutz.gr/search?keyphrase=" + productName);
            }
            // use the html agility pack
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            //get lowest price
            HtmlNode firstNode = doc.DocumentNode.SelectNodes("//a[@class='product-link']").First();
            return double.Parse(firstNode.InnerHtml.Substring(0, firstNode.InnerHtml.Length - 4)) / 100;
        }


        private void ParseWithHtmlDocument(string productName)
        {
            string html;
            productName = productName.Replace(" ", "+");
            // obtain some arbitrary html....
            using (var client = new WebClient())
            {
                //html = client.DownloadString(@"C:/Users/george/Desktop/s.html");
                //html = client.DownloadString("http://www.skroutz.gr/s/8864706/Samsung-Galaxy-J5-2016-16GB.html");
                //html = client.DownloadString("http://www.skroutz.gr/s/6717293/AEG-AG5020.html?keyphrase=%CE%8C%CF%81%CE%B8%CE%B9%CE%B1+%CE%A3%CE%BA%CE%BF%CF%8D%CF%80%CE%B1+AEG+AG+5020+ULTRA+POWER");
                //html = client.DownloadString("http://www.skroutz.gr/search?keyphrase=Όρθια+Σκούπα+AEG+AG+5020+ULTRA+POWER");
                html = client.DownloadString("http://www.skroutz.gr/search?keyphrase=" + productName);
            }
            // use the html agility pack
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a[@class='product-link']").ToArray();

            edtResult.Items.Add(productName);
            foreach (HtmlNode node in nodes)
            {
                edtResult.Items.Add(node.InnerHtml);
            }

            //get lowest price
            HtmlNode firstNode = doc.DocumentNode.SelectNodes("//a[@class='product-link']").First();



        }

        private void chartControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
