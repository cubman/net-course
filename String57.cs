using PT4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PT4Tasks
{
    public class MyTask: PT
    {
        public static void Solve()
        {
            Task("String57");
            Put(
                Regex.Matches
                    (GetString(), @"\\")
                    .Cast<Match>()
                    .Select(x => x.Value)
                    
                    .Last());

        }
    }
}
