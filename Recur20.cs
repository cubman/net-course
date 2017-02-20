using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static int find_comma(string s)
        {
            int op_br_cnt = 0;
            for (var i = 0; i < s.Length; ++i)
                if (s[i] == '(')
                    ++op_br_cnt; else
                    if (s[i] == ')')
                    --op_br_cnt;
                else if (s[i] == ',' && op_br_cnt == 1)
                    return i;
            return -1;
        }

        static int rec(string s)
        {
            if (s[0] == 'M') {
                int rb = find_comma(s);
                return Math.Max(rec(s.Substring(2, rb - 2)), rec(s.Substring(rb+1, s.Length - rb - 2)));
            }

            if (s[0] == 'm')
            {
                int rb = find_comma(s);
                return Math.Min(rec(s.Substring(2, rb - 2)), rec(s.Substring(rb + 1, s.Length - rb - 2)));
            }

            if (char.IsDigit(s[0]))
                return int.Parse(s[0].ToString());

            return 0;
        }
        public static void Solve()
        {
            Task("Recur20");
            int t = rec(GetString());
            Put(t);
        }
    }
}
