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
        class AFS
        {
            public int cost { get; }
            public int type { get; }
            public string name { get; }
            public string street { get; }

            public AFS(int c, int t, string n, string str)
            {
                cost = c;
                type = t;
                name = n;
                street = str;
            }
        }

        public static void Solve()
        {
            Task("LinqObj38");
            var f = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var r = f.Select(x =>
            {
                var s = x.Split(' ');
                return new AFS(int.Parse(s[0]), int.Parse(s[1]), s[2], s[3]);
            }).GroupBy(x => x.type).Select(x => new KeyValuePair<int, int>(x.Count(), x.First().type)).OrderBy(x => x.Key).ThenBy(x => x.Value).Select(x => String.Format("{0} {1}", x.Key, x.Value)).ToArray();
            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
