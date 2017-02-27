using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace PT4Tasks
{
    using System.Xml;
    public class MyTask: PT
    {

        // ��� ������� ����� ������ LinqXml �������� ���������
        // �������������� ������ ����������, ������������ � ���������:
        //
        //   Show() � Show(cmt) - ���������� ������ ������������������,
        //     cmt - ��������� �����������;
        //
        //   Show(e => r) � Show(cmt, e => r) - ���������� ������
        //     �������� r, ���������� �� ��������� e ������������������,
        //     cmt - ��������� �����������.
        static XmlDocument xd = new XmlDocument();
        static void remove(XmlNodeList x, int depth)
        {
            if (depth == 0)
            {
                for (var i = 0; i < x.Count; ++i)             
                    xd.AppendChild(x[i]);

                return;
            }

            for (var i = 0; i < x.Count; ++i)
            {
                xd.AppendChild(x[i]);
                // x[i].Attributes = null;
                remove(x[i].ChildNodes, depth - 1);
            }
        }

        public static void Solve()
        {
            Task("LinqXml25");
            XmlDocument xd1 = new XmlDocument();
            xd1.Load(GetString());
            xd.AppendChild(xd1.DocumentElement.PreviousSibling);
            var t = xd1.ChildNodes;
            remove(t, 2);
            foreach (var x in xd)
                Put(x);
            }
    }
}
