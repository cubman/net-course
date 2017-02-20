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
        class student
        {
            public string name { get; }
            public int year { get; }
            public int school { get; }
            public student(string n, int y, int c)
            {
                name = n;
                year = y;
                school = c;
            }

            public override string ToString()
            {
                return String.Format("{0} {1}", name, school);
            }
        }

        public static void Solve()
        {
            Task("LinqObj21");
            var f = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var m = f.Select(x =>
            {
                var sp = x.Split(' ');
                return new student(sp[0], int.Parse(sp[1]), int.Parse(sp[2]));
            }).GroupBy(x => x.school);
            var mx = m.Max(x => x.Count());

            System.IO.File.WriteAllLines(GetString(), m.Where(x =>x.Count() == mx).Select(x => x.OrderBy(y => y.name).First())
                    .OrderBy( x=>x.name).ThenBy(x=>x.school).Select(x=>x.ToString()).ToArray(), Encoding.Default);
        }
    }
}
