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
            Task("File18");
            var s = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));

            int lg = (int)s.BaseStream.Length, pos = 2 * sizeof(double);
            double a = s.ReadDouble(), b = s.ReadDouble(), c;
            if (a < b)
            {
                Put(a);
                return;
            }

            while (pos < lg)
            {
                c = s.ReadDouble();
                if (a > b && b < c)
                {
                    Put(b);
                    return;
                }
                    
                a = b;
                b = c;

                pos += sizeof(double);
            }

            if (b < a)
                Put(b);
            
        }
    }
}
