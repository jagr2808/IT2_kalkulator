using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kalkulator_prosjekt
{
    class Variabel_tolk
    {
        private static String pattern = @"(\w[\w\d_]+)\s*=\s*(.+)";
        private static Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        private static Dictionary<String, String> variables = new Dictionary<string, string>();


        public static String getResult(String input)
        {
            //Replace variables
            foreach (String key in variables.Keys)
            {
                input = input.Replace(key, variables[key]);
            }

            //Define variables
            Match match = regex.Match(input);
            if (match.Success)
            {
                //Find name and value from match
                Group name = match.Groups[1];
                Group value = match.Groups[2];

                //Resolve value of the variable
                String resolvedValue = Wolfram.getResult(value.Value + "*1");

                Console.WriteLine("[DEBUG] Variabel_tolk.cs: " + name.Value + " bound to " + resolvedValue);

                //Add to dictionary
                variables.Add(name.Value, resolvedValue);
                return "Variabel " + name + "definert til " + resolvedValue + ", gratulerer!";
            }

            //Calculate and return answer
            return Wolfram.getResult(input);
        }


    }
}
