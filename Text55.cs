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
            Task("Text55");
            var ls = new SortedSet<char>();
            var f = new System.IO.StreamReader(GetString(), Encoding.Default);
            var res = new System.IO.BinaryWriter(System.IO.File.Open(GetString(), System.IO.FileMode.OpenOrCreate), Encoding.Default);

            string s;
            while ((s = f.ReadLine()) != null)
                foreach (var x in s)
                    ls.Add(x);

            foreach (var x in ls)
                res.Write(x);
            res.Close();
        }
    }
}
