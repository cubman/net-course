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
    public class MyTask : PT
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
        static Dictionary<string, List<string>> ld = new Dictionary<string, List<string>>();

        static void add(XmlNodeList x)
        {
            if (x.Count == 0)
                return;
            for (var i = 0; i < x.Count; ++i)
            {
                if (x[i].Attributes != null)
                    for (var k = 0; k < x[i].Attributes.Count; ++k)
                        if (ld.ContainsKey(x[i].Attributes[k].Name))
                            ld[x[i].Attributes[k].Name].Add(x[i].Attributes[k].Value);
                        else
                            ld.Add(x[i].Attributes[k].Name, new List<string>() { x[i].Attributes[k].Value });
                add(x[i].ChildNodes);
            }
        }

        public static void Solve()
        {
            Task("LinqXml18");
            XmlDocument xd = new XmlDocument();
            xd.Load(GetString());
            var t = xd.ChildNodes;
            add(t);
            foreach (var x in ld)
            {
                Put(x.Key);
                x.Value.Sort();
                foreach (var p in x.Value)
                    Put(p);
            }
        }
    }
}
