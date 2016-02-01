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

            return UserDataTable;

            //Populate with some test data

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
            //This program is dedicated to building the ablity to read in .csv files, construct data-tables
            //compare values in data tables then return certain values from the table. 

            //Going to start tomorrow beacuse I'm way to tired tonight
        }
    }
}
