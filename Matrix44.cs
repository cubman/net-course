using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static bool sorted(List<double> l, Predicate<double> p)
        {
            var s = l[0];

            for (var i = 1; i < l.Count; ++i)
                if (p(s - l[i]))
                    return false;
                else s = l[i];
            return true;
        }

        static  Tuple<bool, double> is_sorted(List<double> l)
        {
            if (sorted(l, x => x > 0) || sorted(l, x => x < 0))
                return new Tuple<bool, double>(true, l.Min());

            return new Tuple<bool, double>(false, 0);
        }
        public static void Solve()
        {
            Task("Matrix44");
            int M = GetInt();
            List<List<double>> lli = new List<List<double>>(M);
            var N = GetInt();
            for (var j = 0; j < M; ++j)
            {
                lli.Add(new List<double>());
                for (var i = 0; i < N; ++i)
                    lli[j].Add(GetDouble());

            }

            double min = double.MaxValue;

            for (var j = 0; j < M; ++j)
            {
                var s = is_sorted(lli[j]);
                if (s.Item1)
                    min = Math.Min(min, s.Item2);
            }
            if (min == double.MaxValue)
                Put(0.0);
            else Put(min);
        }
    }
}
