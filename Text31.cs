using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("Text31");
            var k = GetInt();
            var t = new System.IO.StreamReader(GetString(), Encoding.Default);
            string s;
            var res = new System.IO.BinaryWriter(System.IO.File.OpenWrite(GetString()), Encoding.Default);
            while((s = t.ReadLine()) != null)
            {
                var r = s.Split(new char[] { ' ', '!', '?', ',',':', '-', '.', ';', '(', ')', '\"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in r)
                    if (x.Length == k)
                        res.Write(x.PadRight(80));
            }
            t.Close();
            res.Close();
        }
    }
}
