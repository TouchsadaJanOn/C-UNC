using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project7
{
    class customers
    {
        public static double _TotalCost;
        public static string name
        {
            get; set;
        }
        public static string email
        {
            get; set;
        }
        public static int age
        {
            get; set;
        }
        public static int LLseats
        {
            get; set;
        }
        public static int CLseats
        {
            get; set;
        }
        public static int UDseats
        {
            get; set;
        }
        public static double TotalCost(int LLseats, int CLseats, int UDseats)
        {
            _TotalCost = (LLseats * 125) + (CLseats * 75) + (UDseats * 50);
            return _TotalCost;
        }

    }
}
