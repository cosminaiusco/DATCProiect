using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase
{
    internal class Data
    {
        public string t { get; set; }
        public string Temp { get; set; }
        public string Umiditate { get; set; }

        public void ToString()
        {
            Console.WriteLine(t + " " + Temp + " " + Umiditate);
        }
    }
}
