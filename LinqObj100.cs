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
            public int code_person { get; }
            public int year { get; }

            public person(string st, int cp, int y)
            {
                street = st;
                code_person = cp;
                year = y;
            }
        }

        class good
        {
            public string good_id { get; }
            public string country { get; }
            public string category { get; }

            public good(string gi, string c, string cat)
            {
                good_id = gi;
                country = c;
                category = cat;
            }
        }

        class shop
        {
            public string shop_name { get; }
            public int cost { get; }
            public string good_id { get; } 

            public shop (string sn, int c, string gi)
            {
                shop_name = sn;
                cost = c;
                good_id = gi;
            }
        }

        class data
        {
            public string good_id { get; }
            public int code_person { get; }
            public string shop_name { get; }

            public data(string gi, int cp, string sn)
            {
                shop_name = sn;
                code_person = cp;
                good_id = gi;
            }
        }

        class resClass
        {
            public string country { get; }
            public string shop_name { get; }
            public int year { get; }
            public int code_person { get; }
            public int cost { get; }

            public resClass(string c, string sn, int y, int cp, int cs)
            {
                country = c;
                shop_name = sn;
                year = y;
                code_person = cp;
                cost = cs;
            }
        }

        class cmp : IEqualityComparer<resClass>
        {
            public bool Equals(resClass x, resClass y)
            {
                return x.country.Equals(y.country) && x.shop_name.Equals(y.shop_name) && x.code_person.Equals(y.code_person) ;
            }

            public int GetHashCode(resClass obj)
            {
                return obj.shop_name.GetHashCode() + obj.shop_name.GetHashCode() + obj.code_person.GetHashCode();
            }

        }

        public static void Solve()
        {
            Task("LinqObj100");
            var a = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new person(s[0], int.Parse(s[1]), int.Parse(s[2]));
            });

            var b = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new good(s[0], s[1], s[2]);
            });

            var d = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new shop(s[0], int.Parse(s[1]), s[2]);
            });

            var e = File.ReadAllLines(GetString(), Encoding.Default).Select(x =>
            {
                var s = x.Split(' ');
                return new data(s[0], int.Parse(s[1]), s[2]);
            });

            var be = b.Join(d, x => x.good_id, y => y.good_id, (x, y) => new { x.country, x.good_id, y.shop_name, y.cost });
            var bed = be.Join(e, x => x.good_id.ToString() + x.shop_name, y => y.good_id.ToString() + y.shop_name, (x, y) => new { x.cost, x.country, y.code_person, y.shop_name });
            var beda = bed.Join(a, x => x.code_person, y => y.code_person, (x, y) => new resClass( x.country, x.shop_name, y.year, x.code_person,  x.cost  ));

            var res = beda.GroupBy(x => new { x.country, x.shop_name }).SelectMany(x =>
            {
                var m = x.Max(y => y.year);
                var t = x.Where(v => v.year == m);
                return t;
            }).OrderBy(x => x.country).ThenBy(x => x.shop_name).ThenBy(x => x.code_person);
            var k = res.Distinct(new cmp()).Select(x => 
            String.Format("{0} {1} {2} {3} {4}", x.country, x.shop_name, x.year, x.code_person,  beda.Where(y => y.country == x.country && y.shop_name == x.shop_name && y.code_person == x.code_person).Sum(y => y.cost))).ToArray();
            File.WriteAllLines(GetString(), k, Encoding.Default);
        }
    }
}
