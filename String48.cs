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
            Task("String48");
            var str = GetString().ToArray();
            int cnt = 0, ch_ind = 0; ;
            bool b = false;
            string res = "";
            char c;
            while (cnt < str.Length)
            {
                if (str[cnt] != ' ')
                {
                    if (!b)
                    {
                        b = true;
                        ch_ind = cnt++;
                        res += str[ch_ind];
                        continue;
                    }
                }
                else b = false;

                if (str[cnt] != ' ')
                    if (str[cnt] == str[ch_ind])
                        c = '.';
                    else c = str[cnt];
                else c = ' ';
                ++cnt;
                res += c;
            }
            Put(res);
        }
    }
}
