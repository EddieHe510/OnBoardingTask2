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


        public static void ClearData()
        {
            dataCol.Clear();
        }


        private static DataTable ExcelToDataTable(string filename, string SheetName)
        {
            FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            // excelReader.IsFirstRowAsColumnNames = true * Does not works anymore

            DataSet resultSet = excelReader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            DataTableCollection table = resultSet.Tables;
            DataTable resultTable = table["SignIn"];
            return resultTable;
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                string data = (from colData in dataCol 
                               where colData.colValue == columnName && colData.rowNumber == rowNumber 
                               select colData.colValue).SingleOrDefault();
                return data.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.ToString());
                return null;
            }
        }

        public static void PopulateInCollection(string filename, string SheetName)
        {
            ExcelLib.ClearData();
            DataTable table = ExcelToDataTable(filename, SheetName);
            // totalRowCount = table.Rows.Count;
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
