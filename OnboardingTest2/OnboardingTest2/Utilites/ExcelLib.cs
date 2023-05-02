using ExcelDataReader;
using System.Data;
using System.Text.Json.Serialization.Metadata;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace CompetitionTask.Utilites
{

    public class ExcelLib
    {
        static List<Datacollection> dataCol = new List<Datacollection>();
        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                // Retriving Data using LINQ to reduce much of iterations
                rowNumber = rowNumber - 1;
                string data = (from colData in dataCol
                               where colData.colValue == columnName && colData.rowNumber == rowNumber
                               select colData.colValue).First().ToString();

                return data.ToString();
            }
            catch (Exception e)
            {
                // Exception message
                // Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.ToString());
                e.Message.ToString();
                return null;
            }
        }

        // Clear the data
        public static void ClearData()
        {
            dataCol.Clear();
        }


        // Import data from excel to table
        private static DataTable ExcelToDataTable(string filename, string sheetName)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table[sheetName];
            return resultTable;
        }

        public static void PopulateInCollection(string filename, string SheetName)
        {
            ExcelLib.ClearData();
            DataTable table = ExcelToDataTable(filename, SheetName);

            // Iterate through the rows and columns of the table
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()
                    };


                    dataCol.Add(dtTable);
                }
            }
        }
    }
}
