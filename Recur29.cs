using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static System.IO.StreamWriter sw;
        static StringBuilder s;
        static int N;

        static void Step(int k, int sum, char c)
        {
            s[k] = c;

            if (sum > 0)
                return;

            if (N == k)
            {
                if (sum == 0)
                    sw.WriteLine(s);
                return;
            }

            Step(k + 1, sum + 1, 'A');
            Step(k + 1, sum, 'B');
            Step(k + 1, sum - 1, 'C');
        }

        public static void Solve()
        {
            Task("Recur29");
            N = GetInt();
            s = new StringBuilder(N);
            
            s.Append('D', N + 1);
            sw = new System.IO.StreamWriter(GetString());

            Step(0, 0, 'D');

            sw.Close();
        }
    }
}
