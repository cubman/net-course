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
            Task("String58");
            
            Put(new string(GetString().Split('\\').Last().TakeWhile(x => x != '.').ToArray()));
        }
    }
}
