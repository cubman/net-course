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
            Task("Text41");
            var f1 = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            var f2 = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            var f3 = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            var res = new System.IO.StreamWriter(System.IO.File.Open(GetString(), System.IO.FileMode.OpenOrCreate));

            var lg = (int)f1.BaseStream.Length / sizeof(int);
            for (var i = 0; i < lg; ++i)
                res.WriteLine(String.Format("|{0,-20}{1,-20}{2,-20}|", f1.ReadInt32(), f2.ReadInt32(), f3.ReadInt32()));
                        
            res.Close();
        }
    }
}
