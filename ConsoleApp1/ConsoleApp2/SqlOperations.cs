using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using ConsoleApp2.Model;

namespace ConsoleApp2
{
    class SqlOperations
    {
        public static string conString = "Server=tcp:cosmina.database.windows.net,1433;Initial Catalog=DATC;Persist Security Info=False;User ID=cosmina;Password=Mihaela8.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public static async void ReadTABLE1()
        {

            SqlConnection conn = new SqlConnection(conString);
            SqlCommand getCommand = null;
            SqlDataReader reader;

            Console.WriteLine("Opening connection");
            Console.ReadLine();
            try
            {
                conn.Open();
                string getDataFromDateTable = "SELECT * FROM TABLE1";
                getCommand = new SqlCommand(getDataFromDateTable, conn);
                reader = getCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ID"]);
                        Console.Write(" ");
                        Console.Write(reader["LATITUDINE"]);
                        Console.Write(" ");
                        Console.WriteLine(reader["LONGITUDINE"]);
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

        public static async void ReadTABLE2()
        {

            SqlConnection conn = new SqlConnection(conString);
            SqlCommand getCommand = null;
            SqlDataReader reader;

            Console.WriteLine("Opening connection");
            Console.ReadLine();
            try
            {
                conn.Open();
                string getDataFromDateTable = "SELECT * FROM TABLE2";
                getCommand = new SqlCommand(getDataFromDateTable, conn);
                reader = getCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.Write(reader["ID"]);
                        Console.Write(" ");
                        Console.Write(reader["TIMP"]);
                        Console.Write(" ");
                        Console.Write(reader["TEMPERATURA"]);
                        Console.Write(" ");
                        Console.WriteLine(reader["UMIDITATE"]);
                    }
                }
            }
            catch (Exception exp)
            {
            }
        }

        public static void InsertDataIntoT1()
        {
            List<T1> ListToInsertIntoT1 = new List<T1>();
            ListToInsertIntoT1.Add(new T1 { ID = 6, LATITUDINE = 5, LONGITUDINE = 60 });

            SqlConnection conn = null;
            SqlCommand insertCommand = null;
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();

                foreach (var item in ListToInsertIntoT1)
                {
                    string insertCmd = string.Format
                    (
                      "INSERT INTO TABLE1 VALUES({0},{1},{2})",
                      item.ID, item.LATITUDINE, item.LONGITUDINE);
                    insertCommand = new SqlCommand(insertCmd, conn);
                    insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception exp) { }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }


        public static void InsertDataIntoT2()
        {
            List<T2> ListToInsertIntoT2 = new List<T2>();
            ListToInsertIntoT2.Add(new T2 { ID = 2, TIMP = DateTime.Now, TEMPERATURA = 25, UMIDITATE = 245 });

            SqlConnection conn = null;
            SqlCommand insertCommand = null;
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();

                foreach (var item in ListToInsertIntoT2)
                {
                    string insertCmd = string.Format
                    (
                      "INSERT INTO TABLE2 VALUES({0},convert(datetime,'{1}'),{2},{3})",
                      item.ID, item.TIMP, item.TEMPERATURA, item.UMIDITATE);
                    insertCommand = new SqlCommand(insertCmd, conn);
                    insertCommand.ExecuteNonQuery();
                    //INSERT INTO TABLE2 VALUES(2,convert(datetime,'12/1/2018 10:59:39'),25,245);
                }
            }
            catch (Exception exp) { }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }



        public static void DeleteID(int id, string table)
        {
            SqlConnection conn = null;
            SqlCommand deleteCommand = null;
            try
            {
                conn = new SqlConnection(conString);
                conn.Open();
                string deleteCmd = string.Format
                ("DELETE FROM {0} WHERE ID = {1}",table,id);
                deleteCommand = new SqlCommand(deleteCmd, conn);
                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception exp) { }
            finally
            {
                if (conn != null)
                    conn.Dispose();
            }
        }




    }
}
