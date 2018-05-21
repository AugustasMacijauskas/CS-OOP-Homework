using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lets use a regular expression to capture data from a few date strings.
            string pattern = @"([a-zA-Z]+) (\d+)";
            MatchCollection matches = Regex.Matches("June 24, August 9, Dec 12", pattern);

            // This will print the number of matches
            Console.WriteLine("{0} matches", matches.Count);

            // This will print each of the matches and the index in the input string
            // where the match was found:
            //   June 24 at index [0, 7)
            //   August 9 at index [9, 17)
            //   Dec 12 at index [19, 25)
            foreach (Match match in matches)
            {
                Console.WriteLine("Match: {0} at index [{1}, {2})",
                    match.Value,
                    match.Index,
                    match.Index + match.Length);
            }

            // For each match, we can extract the captured information by reading the 
            // captured groups.
            foreach (Match match in matches)
            {
                GroupCollection data = match.Groups;
                // This will print the number of captured groups in this match
                Console.WriteLine("{0} groups captured in {1}", data.Count, match.Value);

                // This will print the month and day of each match.  Remember that the
                // first group is always the whole matched text, so the month starts at
                // index 1 instead.
                Console.WriteLine("Month: " + data[1] + ", Day: " + data[2]);

                // Each Group in the collection also has an Index and Length member,
                // which stores where in the input string that the group was found.
                Console.WriteLine("Month found at[{0}, {1})",
                    data[1].Index,
                    data[1].Index + data[1].Length);

                // Lets try and reverse the order of the day and month in a few date 
                // strings. Notice how the replacement string also contains metacharacters
                // (the back references to the captured groups) so we use a verbatim 
                // string for that as well.
                string pattern1 = @"([a-zA-Z]+) (\d+)";

                // This will reorder the string inline and print:
                //   24 of June, 9 of August, 12 of Dec
                // Remember that the first group is always the full matched text, so the 
                // month and day indices start from 1 instead of zero.
                string replacedString = Regex.Replace("June 24, August 9, Dec 12",
                    pattern1, @"$2 of $1");
                Console.WriteLine(replacedString);
            }
        }
    }
}
