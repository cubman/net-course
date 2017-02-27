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
        class person
        {
            public string street { get; }
            public int Birthday { get; }
            public int codeOfCustemer { get; }

            public person(string st, int bd, int coc)
            {
                street = st;
                Birthday = bd;
                codeOfCustemer = coc;
            }
        }

        class good {
            public string good_code { get; }
            public int cost { get; }
            public string shop_name { get; }

            public good(string gc, int c, string sn)
            {
                good_code = gc;
                cost = c;
                shop_name = sn;
            }
        }
        
        class data
        {
            public string shop_name { get; }
            public string good_code { get; }
            public int codeOfCustemer { get; }

            public data(string sn, string gc, int coc)
            {
                shop_name = sn;
                good_code = gc;
                codeOfCustemer = coc;
            }
        }
        public static void Solve()
        {
            Task("LinqObj88");
            var a = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new person(s[0], int.Parse(s[1]), int.Parse(s[2]));
            });

            var d = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new good(s[0], int.Parse(s[1]), s[2]);
            });

            var e = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new data(s[0], s[1], int.Parse(s[2]));
            });

            var ae = a.Join(e, x => x.codeOfCustemer, y => y.codeOfCustemer, (x, y) => new { birday = x.Birthday, shname = y.shop_name, gd_code = y.good_code });
            var aed = ae.Join(d, x => x.gd_code+x.shname , y => y.good_code + y.shop_name, (x, y) => new { x.birday, y.good_code, y.cost });

            var r = aed.GroupBy(x => new { x.birday, x.good_code }).Select(x => 
            {
                var sum = x.Sum(z => z.cost);
                return new { x.First().birday, x.First().good_code, sum };
            }).OrderByDescending(x => x.birday).ThenBy(x=>x.good_code).
                Select(x=> String.Format("{0} {1} {2}", x.birday, x.good_code, x.sum)).ToArray();

            File.WriteAllLines(GetString(), r, Encoding.Default);
        }
    }
}
