using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlOperations.ReadTABLE1();
            SqlOperations.InsertDataIntoT1();
            SqlOperations.ReadTABLE1();
            Console.ReadKey();
        }
    }
}
