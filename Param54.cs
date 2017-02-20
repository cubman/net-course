using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static void splitText(params object[] obj)
        {
            var s = new System.IO.StreamReader(obj[0].ToString(), Encoding.Default);
            var p = new System.IO.StreamWriter(obj[2].ToString(), true, Encoding.Default);
            var t = new System.IO.StreamWriter(obj[3].ToString(), true, Encoding.Default);
            string str;
            int K = int.Parse(obj[1].ToString()), cnt = 1;

            while (cnt++ <= K && (str = s.ReadLine()) != null)
                p.WriteLine(str);

            while ((str = s.ReadLine()) != null)
                t.WriteLine(str);

            s.Close();
            p.Close();
            t.Close();

        }
        public static void Solve()
        {
            Task("Param54");
            splitText(GetString(), GetInt(), GetString(), GetString());
        }
    }
}
