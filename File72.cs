using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        static DateTime get_data(string s)
        {
            var p = s.Split('/');
            return new DateTime(int.Parse(p[2]), int.Parse(p[1]), int.Parse(p[0]));
        } 


        public static void Solve()
        {
            Task("File72");
            var str = new System.IO.StreamReader(System.IO.File.Open(GetString(), System.IO.FileMode.Open));
            DateTime res = new DateTime();
            
            string s;
            while ((s = str.ReadLine()) != null)
            {
                var d = s.Split(new char[] { ' ', 'P' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in d)
                {
                    var dt = get_data(x);
                    if ((dt.Month >= 9 && dt.Month <= 11) && (res == new DateTime() || res.Year < dt.Year || res.Year == dt.Year && res.Month < dt.Month || res.Year == dt.Year && res.Month == dt.Month && res.Day < dt.Day))
                            res = dt;
                        
                }
            }
            str.Close();
            if (res == new DateTime())
                Put("");
            else
                Put(res.ToString("dd/MM/yyyy").Replace('.','/'));
        }
    }
}
