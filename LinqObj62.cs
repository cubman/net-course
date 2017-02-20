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
            public int cls { get; }
            public string fname { get; }
            public string sname { get; }
            public string fullname { get; }
            public int geo { get; }
            public int mth { get; }
            public int ict { get; }

            public pupil(int cl, string fn, string sn, int g = 0, int m = 0, int i = 0)
            {
                cls = cl;
                fname = fn;
                sname = sn;
                fullname = fname + " " + sname;
                geo = g;
                mth = m;
                ict = i;
            }
        }

        public static void Solve()
        {
            Task("LinqObj62");
            var a = File.ReadAllLines(GetString(), Encoding.Default);
            var t = a.Select( x => {
                var s = x.Split(' ');
                var d = int.Parse(s[3]);
                return new pupil(int.Parse(s[0]), s[1], s[2], s[4].Equals("Алгебра") ? d : 0, s[4].Equals("Геометрия") ? d : 0, s[4].Equals("Информатика") ? d : 0 );
            }).GroupBy(x => new {x.cls, x.fname, x.sname}).Select (x=>new pupil(x.First().cls, x.First().fname, x.First().sname, x.Count(y => y.geo >= 2 && y.geo <= 5), x.Count(y => y.mth >= 2 && y.mth <= 5), x.Count(y=> y.ict >= 2 && y.ict <= 5))).OrderBy(x => x.cls).ThenBy(x=>x.fullname).Select(x=> String.Format("{0} {1} {2} {3} {4}", x.cls, x.fullname, x.geo, x.mth, x.ict)).ToArray();
            File.WriteAllLines(GetString(), t, Encoding.Default);
        }
    }
}
