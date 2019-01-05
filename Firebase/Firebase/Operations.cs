using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using System.Threading;

namespace Firebase
{
    internal class Operations
    {
        public int nrInfo = 0;
        public int time = 1000;
        public bool changed = false;
        public int counter = 0;
        public bool connection = false;
        public IFirebaseClient client;

        //connect to Firebase
        static IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "Cyb0tmIxK2mIsGTii8jSZW42r3feicQ9QWJBH7R9",
            BasePath = "https://datc-85258.firebaseio.com//"
        };

        public void init()
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)
            {
                Console.WriteLine("conectat");
                connection = true;
            }
            else
                Console.WriteLine("neconectat");

        }

        public async void ReadNumber()
        {
            if (connection == true)
            {
                FirebaseResponse response = await client.GetAsync("Counter/node/cnt/");
                //Thread.Sleep(2000);
                string nr= "0";
                nr = response.ResultAs<string>();
                if (nrInfo != Int32.Parse(nr))
                {
                    nrInfo = Int32.Parse(nr);
                    changed = true;
                    Console.WriteLine("Changed!!!!");
                }
            }
            
            /*StreamWriter sw = new StreamWriter("C:\\Users\\Cosmina\\Desktop\\steliana\\nrSensors.txt");
            sw.WriteLine(nrInfo);
            sw.Close();*/
        }


        public async void ReadData()
        {   
            if(connection==true)
            {
                if (nrInfo != 0 && changed == true)
                {
                    Data d = null;

                    while (counter < nrInfo)
                    {
                        counter++;

                        FirebaseResponse response1 = await client.GetAsync("s1/" + counter + "/");
                        Thread.Sleep(time);
                        d = response1.ResultAs<Data>();
                        SqlOperations.InsertDataIntoT2(1, DateTime.Parse(d.t),float.Parse(d.Temp),float.Parse(d.Umiditate));
                        d.ToString();

                        FirebaseResponse response2 = await client.GetAsync("s2/" + counter + "/");
                        Thread.Sleep(time);
                        d = response2.ResultAs<Data>();
                        SqlOperations.InsertDataIntoT2(1, DateTime.Parse(d.t), float.Parse(d.Temp), float.Parse(d.Umiditate));
                        d.ToString();

                        FirebaseResponse response3 = await client.GetAsync("s3/" + counter + "/");
                        Thread.Sleep(time);
                        d = response3.ResultAs<Data>();
                        SqlOperations.InsertDataIntoT2(1, DateTime.Parse(d.t), float.Parse(d.Temp), float.Parse(d.Umiditate));
                        d.ToString();

                        FirebaseResponse response4 = await client.GetAsync("s4/" + counter + "/");
                        Thread.Sleep(time);
                        d = response4.ResultAs<Data>();
                        SqlOperations.InsertDataIntoT2(1, DateTime.Parse(d.t), float.Parse(d.Temp), float.Parse(d.Umiditate));
                        d.ToString();
                        
                    }
                }
            }
        }
    }
}
