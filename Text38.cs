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
            Task("Text38");
            var k = GetInt();
            var f = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            
        }
    }
}
