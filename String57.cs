using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String57");
            Put(string.Join(" ", GetString().Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries)));
        }
    }
}
