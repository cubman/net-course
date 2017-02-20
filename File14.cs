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
            Task("File14");

            var s = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            double res = 0;
            int cnt = 0, lg = (int)s.BaseStream.Length, pos = 0;

            while (pos < lg)
            {
               res += s.ReadDouble();
               cnt += 1;
               pos += sizeof(double);
            }

            s.Close();
            Put(cnt == 0 ? 0 : res / cnt);
        }
    }
}
