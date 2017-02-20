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
        class data_d
        {
            public int y {
                get; set; }
            public int h {
                get; set; }
            public int sp {
                get; set; }
            public int id {get; set;}

            public data_d(int a, int b, int c, int d)
            {
                y = a;
                h = b;
                sp = c;
                id = d;
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", y, sp);
            }
        }

        public static void Solve()
        {
            Task("LinqObj3");
            var spl = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            System.IO.File.WriteAllText(GetString(), spl.Select(s =>
            {
                var sp = s.Split(' ');
                return new data_d(int.Parse(sp[0]), int.Parse(sp[1]), int.Parse(sp[2]), int.Parse(sp[3]));
            }).GroupBy(x => x.y).Select(x => new data_d(x.First().y, 0, x.Sum(el => el.sp), 0)).OrderByDescending(x => x.sp).ThenBy(x=> x.y).First().ToString());
        }
    }
}
