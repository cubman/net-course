using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static string to_bin(int d)
        {
            string res = "";
            while (d > 0)
            {
                res = (d % 2).ToString() + res;
                d /= 2;
            }
            return res;
        }
        public static void Solve()
        {
            Task("String25");
            Put(to_bin(int.Parse(GetString())));
        }
    }
}
