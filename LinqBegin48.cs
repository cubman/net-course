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

        public static void Solve()
        {
            Task("LinqBegin48");
            var A = GetEnumerableString();
            var B = GetEnumerableString();
            var t = new List<KeyValuePair<string, string>>();
            foreach (var i in A)
                foreach (var j in B)
                    if (i.Length == j.Length)
                        t.Add(new KeyValuePair<string, string>(i, j));
            t.OrderBy(x => x.Key).ThenByDescending(x => x.Value).Select(x => x.Key + ":" + x.Value).Put();
                }
    }
}
