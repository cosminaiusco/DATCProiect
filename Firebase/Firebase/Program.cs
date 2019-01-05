using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Firebase
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations o = new Operations();
            o.init();
            while (true)
            {
                o.ReadNumber();
                Thread.Sleep(4000);
                o.ReadData();
                Thread.Sleep(4000);
            }
            //Console.ReadKey();
        }
    }
}
