using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kalkulator_prosjekt
{
    class Wolfram
    {
        private const string apiId = "94GXRJ-8HKWKH6PY8";

        public static string getResult(string s)
        {
            string r = "";
            XmlDocument xml = new XmlDocument();
            try
            {
                string api = "http://api.wolframalpha.com/v2/query?input=" + Uri.EscapeDataString(s) + "&appid=" + apiId;
                Console.Write(api);
                xml.LoadXml(new WebClient().DownloadString(api));
            }
            catch
            {
                throw new Exception("API error, check internetconnection");
            }

            try
            {
                XmlNode x = xml.SelectSingleNode("descendant::pod[@id='Result']").SelectSingleNode("descendant::plaintext");
                r = x.InnerText;
            }
            catch
            {
                throw new Exception("Wrong format");
            }
            
            return r;
        }
    }
}
