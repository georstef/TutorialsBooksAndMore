using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_chapter14_linq_wpf
{
  using System.Windows.Media.Imaging;

    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public int Year { get; set; }
        public string CoverPrice { get; set; }
        public string Synopsis { get; set; }
        public string MainVillain { get; set; }
        public BitmapImage Cover { get; set; }
    }
}
