using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTables
{
    class Program
    {

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

        static DataTable createUserClassTable()
        {

            DataTable userCourseDataTable = new DataTable();

            //define course table(where data will end up)
            userCourseDataTable.Columns.Add("StudentID", typeof(string));
            userCourseDataTable.Columns.Add("Course1", typeof(string));
            userCourseDataTable.Columns.Add("Course2", typeof(string));
            userCourseDataTable.Columns.Add("Course3", typeof(string));
            userCourseDataTable.Columns.Add("Course4", typeof(string));
            userCourseDataTable.Columns.Add("Course5", typeof(string));
            userCourseDataTable.Columns.Add("Course6", typeof(string));

            return userCourseDataTable;
        }

        public static DataTable loadSetFromCSV(string filePath)
        {
            DataTable csvDt = new DataTable();
           
            //read .csv into string[]
            string[] csvRows = System.IO.File.ReadAllLines(filePath); 
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

        //findAndCompare(DataTable  orTwo asParam?){}

        //ReturnResult(){}


        static void Main(string[] args)
        {
            DataTable userDataTable = createUserClassTable();
            DataTable userCourseTable = createUserClassTable();
            DataTable mainCsvDataTable = loadSetFromCSV("C:\\Users\\James\\Student_List.csv"); // User option to change path in application

            Console.ReadKey(); // And she works :D


        }
    }
}
