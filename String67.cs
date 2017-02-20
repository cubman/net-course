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
            Task("String67");
            var g_str = GetString();
            string res = new string(g_str.Substring(g_str.Length / 2).Reverse().ToArray());
            int cnt = 0;
            for (var i = 1; i < g_str.Length ; i += 2)
                res = res.Insert(i, g_str[cnt++].ToString());
            Put(res);
        }
    }
}
