using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // Для чтения набора строк из исходного текстового файла
        // в массив a типа string[] используйте оператор:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // Для записи последовательности s типа IEnumerable<string>
        // в результирующий текстовый файл используйте оператор:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // При решении задач группы LinqObj доступны следующие
        // дополнительные методы расширения, определенные в задачнике:
        //
        //   Show() и Show(cmt) - отладочная печать последовательности,
        //     cmt - строковый комментарий;
        //
        //   Show(e => r) и Show(cmt, e => r) - отладочная печать
        //     значений r, полученных из элементов e последовательности,
        //     cmt - строковый комментарий.
        class pupil
        {
            public int school { get; }
            public int mth { get; }
            public int rus { get; }
            public int ict { get; }
            public string fname { get; }
            public string sname { get; }

            public pupil (int sc, int mt, int rs, int it, string fn, string sn)
            {
                school = sc;
                mth = mt;
                rus = rs;
                ict = it;
                fname = fn;
                sname = sn;
            }
        }

        public static void Solve()
        {
            Task("LinqObj59");
            var a = File.ReadAllLines(GetString(), Encoding.Default);
            var r = a.Select(x =>
             {
                 var s = x.Split(' ');
                 return new pupil(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), int.Parse(s[3]), s[4], s[5]);
             }).GroupBy(x => x.school).Select(x => new pupil(x.First().school, x.Count(y => y.mth >= 50), x.Count(y => y.rus >= 50), x.Count(y => y.ict >= 50), "", "")).
                    OrderBy(x => x.school).Select(x => String.Format("{0} {1} {2} {3}", x.school, x.mth, x.rus, x.ict)) .ToArray();
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
