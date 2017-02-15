using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mysqltry1
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSet1.athsportDataTable t1 = new DataSet1TableAdapters.athsportTableAdapter().GetData();
            //var t1 = new DataSet1TableAdapters.athsportTableAdapter().GetData();

            foreach (DataRow row in t1.Rows)
            {
                foreach (DataColumn col in t1.Columns)
                {
                    Console.Write(row[col].ToString().Trim() + " ");
                }
                Console.WriteLine();
            }


            ////----------- DEVART  -----------------------------------------------
            //DataSet2.athathleteDataTable t2 = new DataSet2.athathleteDataTable();
            //t2.Fill();

            ////DataSet2TableAdapters.athsportTableAdapter().GetData();
            ////var t1 = new DataSet1TableAdapters.athsportTableAdapter().GetData();

            //foreach (DataRow row in t2.Rows)
            //{
            //    foreach (DataColumn col in t2.Columns)
            //    {
            //        Console.Write(row[col].ToString().Trim() + " ");
            //    }
            //    Console.WriteLine();
            //}


            Console.ReadKey();
        }
    }
}
