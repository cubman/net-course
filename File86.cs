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
            Task("File86");
            var f = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            var res = new System.IO.BinaryWriter(System.IO.File.Open(GetString(), System.IO.FileMode.OpenOrCreate));

            var sz = (int)Math.Sqrt((int)f.BaseStream.Length / sizeof(double) * 2);
            for (var i = 0; i < sz; ++i)
            {
                for (var k = sz - i; k < sz; ++k)
                    res.Write(0.00);
                
                for (var k = i; k < sz; ++k)
                    res.Write(Math.Round(f.ReadDouble(),2));
            }
            f.Close();
            res.Close();
        }
    }
}
