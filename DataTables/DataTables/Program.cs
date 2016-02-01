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

            UserDataTable.Columns.Add("StudentID", typeof(string));
            UserDataTable.Columns.Add("Last name", typeof(string));
            UserDataTable.Columns.Add("First name", typeof(string));

            UserDataTable.Rows.Add("PXXXXXXXX", "Zero", "Test"); //fill with some sample data
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
            string[] csvRows = System.IO.File.ReadAllLines(filePath);
            string[] fields = null;
            int counter = 0;
            foreach(string Row in csvRows)
            {
                fields = csvRows[counter].Split(',');
                DataRow dataRow = csvDt.NewRow();
                dataRow.ItemArray = fields;
                csvDt.Rows.Add(dataRow);
                counter++;
            }
            return csvDt;
        }

        //findAndCompare(){}

        //querAndReturnResult(){}


        static void Main(string[] args)
        {
            DataTable userDataTable = createUserClassTable();
            DataTable userCourseTable = createUserClassTable();
            DataTable mainCsvDataTable = loadSetFromCSV("path"); // User option to change path in application

            
        }
    }
}
