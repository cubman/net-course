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
            var res = new System.IO.BinaryWriter(System.IO.File.Open(GetString(), System.IO.FileMode.OpenOrCreate));
            var f_arch = new System.IO.BinaryReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));

            /* string s;
             while ((s = f_arch.ReadLine()) != null)
             {
                 var sp = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                 foreach(var fl in sp)
                 {
                     var f = new System.IO.BinaryReader(System.IO.File.Open(fl, System.IO.FileMode.Open));
                     var lg = (int)f.BaseStream.Length / sizeof(int);
                     var res_d = 0.0;
                     for (var k = 0; k < lg; ++k)
                         res_d += f.ReadInt32();
                     res.Write(res_d / lg);
                     f.Close();
                 }
             }*/

            var lg = (int)f_arch.BaseStream.Length / sizeof(int);
            var res_d = 0.0;
            for (var k = 0; k < lg; ++k)
                res_d += f_arch.ReadInt32();
            res.Write(res_d / lg);
            res.Close();
        }
    }
}
