using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    using System.IO;

    public class MyTask: PT
    {
        
        static void writing(BinaryWriter sw, BinaryReader sr)
        {
           int lg = (int)sr.BaseStream.Length / sizeof(int);

           for (var i = 0; i < lg; ++i)
                sw.Write(sr.ReadInt32());
            
            sr.Close();
        }

        public static void Solve()
        {
            Task("File36");
            var fname = GetString();
            var str_w = new System.IO.BinaryWriter(File.Open("mid.txt", FileMode.OpenOrCreate));
            var str_r = new System.IO.BinaryReader(File.Open(fname, FileMode.Open));

            writing(str_w, str_r);
            str_r = new System.IO.BinaryReader(File.Open(fname, FileMode.Open));
            writing(str_w, str_r);
            str_w.Close();

            File.Delete(fname);
            File.Move("mid.txt", fname);
        }
    }
}
