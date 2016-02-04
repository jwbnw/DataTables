/*************************************************
        Program Name: Data Tables
        Author: James Belford
        Description: This program was built to
        have some fun with datatables and importing
        .csv files. Part of a larger porject I am
        working on
        Date:  2/4/16
        Author: James Belford 
*******************************************************/

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTables;

namespace DataTables
{
    class Program
    {

        /*************************************************
         Method Name: createUserSampleDataTable()
         Type: DataTable.
         Description: This method creates a datatable
         it then add's some test values. NOTE: I don't
         currently use this method, yet I am leaving it
         in for later user.
         Arguments: (O) userDataTable - DataTable
         Author: James Belford 
         *************************************************/
        static DataTable createUserSampleTable()
        {
            DataTable UserDataTable = new DataTable();

            //define user columns
            UserDataTable.Columns.Add("StudentID", typeof(string));
            UserDataTable.Columns.Add("Last name", typeof(string));
            UserDataTable.Columns.Add("First name", typeof(string));

            //fill with some sample data
            UserDataTable.Rows.Add("PXXXXXXXX", "Zero", "Test");
            UserDataTable.Rows.Add("PXXXXXXXX", "One", "Test");
            UserDataTable.Rows.Add("PXXXXXXXX", "Two", "Test");
            UserDataTable.Rows.Add("PXXXXXXXX", "Three", "Test");
            UserDataTable.Rows.Add("PXXXXXXXX", "Four", "Test");
            UserDataTable.Rows.Add("PXXXXXXXX", "Five", "Test");

            return UserDataTable;

        }

        /*************************************************
         Method Name: loadSetFromCSV()
         Type: DataTable.
         Description: This method reads in a .csv file
         and constructs a data table from the .csv.
         It is composed of two parts. One part creates
         the colums headers. The rest writes all the rows
         Arguments: (I) filePath - string
                    (O) csvDT - DataTable
         Author: James Belford 
         *************************************************/

        public static DataTable loadSetFromCSV(string filePath)
        {
            DataTable csvDt = new DataTable();
            string[] csvRows = null;
            //read .csv into string[]

            //Try catch block in the event of the .csv being open @ at different location
            //While loop is self-explanatory 
            while (csvRows == null)
            {
                try
                {
                    csvRows = System.IO.File.ReadAllLines(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine("IOException source: {0}", e.Source);
                    Console.WriteLine("Error please close Exceel then press Enter");
                    Console.ReadKey();
                }
            }
            string[] fields = null;

            //take the header row and split it up
            string colHeaders = csvRows[0];
            string[] headerFeilds = colHeaders.Split(',');

            //Asign columns based on header names
            foreach (string column in headerFeilds)
            {
                DataColumn headers = new DataColumn(column);

                csvDt.Columns.Add(headers);

            }

            //Note: These are extra columns beacuse for some reason some rows are longer than the header row? Anyway, I'll write a sub-routiene to tidy that up when I have time
            DataColumn spacer = new DataColumn("Spacer");
            DataColumn spacer1 = new DataColumn("Spacer1");

            csvDt.Columns.Add(spacer);
            csvDt.Columns.Add(spacer1);

            //take each row of data, read it into data row then add to data table
            for (int i = 1; i < csvRows.Length; i++)
            {
                fields = csvRows[i].Split(',');
                DataRow dataRow = csvDt.NewRow();
                dataRow.ItemArray = fields;
                csvDt.Rows.Add(dataRow);
            }
            return csvDt;
        }

        /*************************************************
     Method Name: rowToPullFrom()
     Type: List.
     Description: This method takes in a DataTable
     and string. The DataTable is the csvDataTable with
     all  user values, the string is the ID. We then use
     the ID to find the rows we need. We then move them 
     into a DataRow array. Which we then throw those 
     values into a list a return said list.
     Arguments: (I) originalUserPid - string
                (I) csvDataTable - DataTable
                (O) s - List
     Author: James Belford 
     *************************************************/
        public static List<string> rowToPullFrom(string originalUserPid, DataTable csvDataTable) 
        {

            DataRow[] Classtemp = csvDataTable.Select("PEOPLE_CODE_ID='" + originalUserPid + "'");

            // A damn nifty line of code if I may say so myself, essentially using LINQ 
            List<string> s = Classtemp.AsEnumerable().Select(x => x.Field<string>("Class").ToString()).ToList();

            //For debugging 
            foreach (string e in s)    
                Console.WriteLine(e);
            return s;
        }


        //Main 
        static void Main(string[] args)
        {
            DataTable userDataTable = createUserSampleTable();
            DataTable mainCsvDataTable = loadSetFromCSV("C:\\Users\\James\\Student_List.csv"); // User option to change path in application

            List<string> finalList = rowToPullFrom("ID HERE", mainCsvDataTable); //Gotem

            Console.ReadKey();

        }
    }
}
