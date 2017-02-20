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
        // ��� ������ ������ ����� �� ��������� ���������� �����
        // � ������ a ���� string[] ����������� ��������:
        //
        //   a = File.ReadAllLines(GetString(), Encoding.Default);
        //
        // ��� ������ ������������������ s ���� IEnumerable<string>
        // � �������������� ��������� ���� ����������� ��������:
        //
        //   File.WriteAllLines(GetString(), s.ToArray(), Encoding.Default);
        //
        // ��� ������� ����� ������ LinqObj �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.
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
