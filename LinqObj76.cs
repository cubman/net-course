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
        class good
        {
            public string id { get; }
            public string shopName { get; }
            public int cost { get; }

            public good (string i, string sn, int c)
            {
                id = i;
                shopName = sn;
                cost = c;
            }
        }

        class country
        {
            public string id { get; }
            public string category { get; }
            public string good { get; }

            public country(string i, string c, string for_key)
            {
                id = i;
                category = c;
                good = for_key;
            }
        }

        class resClass : IEqualityComparer<resClass>
        {
            public string id { get; }
            public string cat { get; }
            public string shN { get; }
            public int cst { get; }

            public resClass(string i, string c, string s, int ct)
            {
                id = i;
                cat = c;
                shN = s;
                cst = ct;
            }

            public bool Equals(resClass x, resClass y)
            {
                return x.shN.Equals(y.shN);
            }

            public int GetHashCode(resClass obj)
            {
                return obj.shN.GetHashCode() ;
            }

        }
        public static void Solve()
        {
            Task("LinqObj76");
            var a = File.ReadAllLines(GetString(), Encoding.Default).Select(x => {
                var s = x.Split(' ');
                return new country(s[0], s[1], s[2]);
            });

            var b = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new good(s[0], s[1], int.Parse(s[2]));
            });

            var t =
                from v1 in a
                from v2 in b.Where(j => j.id == v1.good).DefaultIfEmpty(new good("", "", int.MaxValue))
                select new resClass(v1.id, v1.category, v2.shopName, v2.cost);
                

           // foreach (var q in t)
                //if (q != null)
              //  Console.Write(q.id, ' ', q.cst, ' ', q.shname, ' ', q.cat);
                
            var res = t.GroupBy(x => x.id).Select(x => 
            {
                var w = x.Distinct();
                    return new Tuple<int, string, int>(  w.Count(), w.First().id,  w.Min(p => p.cst) );
            }).OrderBy(x => x.Item1).ThenByDescending(x=>x.Item2).Select(x => String.Format("{0} {1} {2}", x.Item1, x.Item2, x.Item3)).ToArray();
            File.WriteAllLines(GetString(), res,  Encoding.Default);
        }
    }
}
