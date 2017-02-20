using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        // ��� ������� ����� ������ LinqBegin �������� ���������
        // �������������� ������, ������������ � ���������:
        //
        //   GetEnumerableInt() - ���� �������� ������������������;
        //
        //   GetEnumerableString() - ���� ��������� ������������������;
        //
        //   Put() (����� ����������) - ����� ������������������;
        //
        //   Show() � Show(cmt) (������ ����������) - ���������� ������
        //     ������������������, cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) (������ ����������) -
        //     ���������� ������ �������� r, ���������� �� ��������� e
        //     ������������������, cmt - ��������� �����������.
        class st
        {
            public int cl { get; }
            public int sm { get; }

            public st(int c, List<int> lst)
            {
                cl = c;
                sm = lst.Sum();
            }
        }

        public static void Solve()
        {
            Task("LinqBegin51");
            var A = GetEnumerableInt();
            var B = GetEnumerableInt();
            var d = B.GroupBy(x => x % 10).Select(x => new st(x.First() % 10, x.ToList()));
            List<KeyValuePair<int, int>> l = new List<KeyValuePair<int, int>>();
            bool b = false;
            foreach (var x in A)
            {
                foreach (var t in d)
                    if (t.cl == x % 10) { 
                        l.Add(new KeyValuePair<int, int>(t.sm, x));
                        b = true;
                        break;
                    }
                if (!b)
                    l.Add(new KeyValuePair<int, int>(0, x));
                b = false;
            }


            l.OrderBy(x => x.Key).ThenByDescending(x => x.Value).Select(x => String.Format("{0}:{1}", x.Key, x.Value)).Put();
        }
    }
}
