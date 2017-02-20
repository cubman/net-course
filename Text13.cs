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
            Task("Text13");
            var n = GetString();
            var s = new System.IO.StreamReader(n, Encoding.Default);
            var f = new System.IO.StreamWriter("m.txt", true, Encoding.Default);
            var k = s.ReadLine();
            while ((k = s.ReadLine()) != null)
                f.WriteLine(k);
            s.Close();
            f.Close();
            System.IO.File.Delete(n);
            System.IO.File.Move("m.txt", n);

        }
    }
}
