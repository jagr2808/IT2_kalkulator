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
        private static String pattern = @"(\w[\w\d]+)=(.+)";
        private static Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
        private static Dictionary<String, String> variables = new Dictionary<string, string>();


        public static String getResult(String input)
        {
            Console.WriteLine(variables.Count);

            //Replace variables
            foreach (String key in variables.Keys)
            {
                input = input.Replace(key, variables[key]);
                Console.WriteLine(key + " = " + variables[key]);
            }

            //Define variables
            Match match = regex.Match(input);
            if (match.Success)
            {
                //Find name and value from match
                Group name = match.Groups[1];
                Group value = match.Groups[2];

                Console.WriteLine("[DEBUG] Variabel_tolk.cs: " + name.Value + " bound to " + value.Value);

                //Add to dictionary
                variables.Add(name.Value, value.Value);
                return "Variabel definert, gratulerer!";
            }
            return input;
        }


    }
}
