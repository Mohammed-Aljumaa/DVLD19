using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DvldBusinessLayer;

namespace MangePeopleLayer
{
    internal class Program
    {


        static void ListPeople()
        {
            DataTable dt = clsMangepeople.GetAllPeople();

            foreach (DataRow Row in dt.Rows)
            {
                Console.WriteLine($"{Row["PersonID"]},{Row["NationalNo"]},{Row["NationalNo"]}{Row["FirstName"]},{Row["SecondName"]},{Row["ThirdName"]},{Row["LastName"]}");
            }
        }
        static void Main(string[] args)
        {

            ListPeople();

            Console.ReadLine();
        }
    }
}
