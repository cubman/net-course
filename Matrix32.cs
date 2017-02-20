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
            Task("Matrix32");
            int M = GetInt();
            List<List<int>> lli = new List<List<int>>(M);
            var N = GetInt();
            for (var j = 0; j < M; ++j)
            {
                lli.Add(new List<int>());
                for (var i = 0; i < N; ++i)
                    lli[j].Add(GetInt());
               
            }
            for (var j = 0; j < M; ++j)
                if (lli[j].Count(x => x > 0) == lli[j].Count(x => x < 0))
            {
                Put(j + 1);
                return;
            }
            Put(0);
        }
    }
}
