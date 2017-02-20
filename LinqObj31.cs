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

        class indweller
        {
            public string name { get; }
            public double must_pay { get; }
            public int flat { get; }
            public int porch { get; }

            public indweller(double d, string n, int f)
            {
                name = n;
                must_pay = d;
                flat = f;
                porch = (int)Math.Floor(f / 36.1) + 1;
            }

            public override string ToString()
            {
                return String.Format("{0} {1} {2} {3}", must_pay.ToString("0.00").Replace(',', '.'), porch, flat, name);
            }
        }

        public static void Solve()
        {
            Task("LinqObj31");
            var f = System.IO.File.ReadAllLines(GetString(), Encoding.Default);
            var p = f.Select(x =>
            {
                var s = x.Split(' ');
                var a1 = double.Parse(s[0].Replace('.',','));
                return new indweller(a1, s[1], int.Parse(s[2]));
            }).GroupBy(x => x.porch).SelectMany(x => x.OrderByDescending(y => y.must_pay).Take(3)).
            OrderByDescending(x => x.must_pay).Select(x => x.ToString()).ToArray();
            File.WriteAllLines(GetString(), p, Encoding.Default);
        }
    }
}
