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
            Task("File54");
            var res = new System.IO.BinaryWriter(System.IO.File.OpenWrite(GetString()));
            var f_arch = new System.IO.BinaryReader(System.IO.File.OpenRead(GetString()));
            List<int> ls = new List<int>();
            int N = f_arch.ReadInt32();
            for (var i = 0; i < N; ++i)
                ls.Add(f_arch.ReadInt32());

            for (var i = 0; i < N; ++i) {
                int sum = 0;
                for (var j = 0; j < ls[i]; ++j)
                    sum += f_arch.ReadInt32();
                res.Write(sum / (double)ls[i]);
              }
            res.Close();
            f_arch.Close();
        }
    }
}
