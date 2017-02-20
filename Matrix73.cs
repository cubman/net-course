using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static List<List<double>> transp(List<List<double>> l, int M, int N)
        {
            List<List<double>> l_res = new List<List<double>>();

            for (var i = 0; i < M; ++i)
            {
                l_res.Add(new List<double>());

                for (var j = 0; j < N; ++j)
                    l_res[i].Add(l[j][i]);
                        }
            return l_res;
        }

        public static void Solve()
        {
            Task("Matrix73");
            int M = GetInt();
            var N = GetInt();
            List<List<double>> lli = new List<List<double>>(N);

            for (var i = 0; i < N; ++i)
                lli.Add(new List<double>());

            for (var i = 0; i < M; ++i)
                for (var j = 0; j < N; ++j)
                    lli[j].Add(GetDouble());
            List<double> nl = new List<double>(N);
            for (var i = 0; i < M; ++i)
                nl.Add(0.0);

            for (var i = N - 1; i >= 0; --i)
                if (lli[i].FindIndex(x => x >= 0) == -1)
                {
                    lli.Insert(i + 1, nl);
                    ++N;
                    break;
                }

            var tr = transp(lli, M, N);
            for (var i = 0; i < M; ++i)
                for (var j = 0; j < N; ++j)
                    Put(tr[i][j]);
        }
    }
}
