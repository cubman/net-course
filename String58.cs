using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PT4Tasks
{

    public class MyTask : PT
    {
        public static void Solve()
        {
            Task("String58");
            Put(Regex.Match(GetString(), @"(\w+)(.?\w*)$").Groups[1].Value);
        }
    }
}

