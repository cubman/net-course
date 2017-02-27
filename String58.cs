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
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[^\\]");
            var p = r.Split(GetString());
            
            Put(new string(p.Last().TakeWhile(x => x != '.').ToArray()));
        }
    }
}
