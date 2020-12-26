using System;
using System.Globalization;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;

namespace Generator_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x;
            double y;
            int a = 2, b = 5;
            string final;
            var random = new Random();
            string title = "x,y";
            var ListFinal = new List<string>();

            ListFinal.Add(title);

            for(int i = 1; i < 51; i++)
            {
                //i = random.Next(51);
                y = a * i + b + (random.NextDouble() / 10.0);
                final = i.ToString() + "," + y.ToString(CultureInfo.InvariantCulture);
                ListFinal.Add(final);

                Console.WriteLine("String " + i + " has been written");
            }

            WriteToExcel(ListFinal);
        }

        public static void WriteToExcel(List<string> ListFinal)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workBook = excelApp.Workbooks.Add();
            Excel.Worksheet workSheet = workBook.ActiveSheet;
            int i = 1;

            foreach (string s in ListFinal)
            {
                workSheet.Cells[i, "A"] = s;
                i++;
            }
            workBook.Close(true, "E:\\KPI\\Lab.xlsx");
            excelApp.Quit();
            Console.WriteLine("Export is end.");
        }
    }
}
