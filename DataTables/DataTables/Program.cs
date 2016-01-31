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

        //loadSetFromCSV(){}

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
