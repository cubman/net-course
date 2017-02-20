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

        public static void Solve()
        {
            Task("LinqXml3");
            var f = new System.IO.StreamReader(GetString(), Encoding.Default);
            XmlDocument d = new XmlDocument();
            d.AppendChild(d.CreateXmlDeclaration("1.0", "windows-1251", null));
            XmlElement bookDescriptions = d.CreateElement("root");
            d.AppendChild(bookDescriptions);
            string s;
            int i = 0;
            while ((s = f.ReadLine()) != null)
            {
                var el = d.CreateElement("line");
                var at = d.CreateAttribute("num");
                at.InnerText = (++i).ToString();
                el.Attributes.Append(at);
                //el.Value =i.ToString();
                el.InnerText = s;
                bookDescriptions.AppendChild(el);
               // ++i;
            }
            d.Save(GetString());
        }
    }
}
