using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace EmailRegEx
{
    public class TldValidator
    {
        public List<string> ValidTlds
        {
            get { return _ValidTlds ?? (_ValidTlds = GetValidTlds()); }
            set { _ValidTlds = value; }
        } private List<string> _ValidTlds;

        public bool IsValidTld(string tld)
        {
            return ValidTlds.Any(validTld => validTld.Equals(tld, StringComparison.OrdinalIgnoreCase));
        }

        private List<string> GetValidTlds()
        {
            var list = new List<string>();
            var request = WebRequest.Create("http://data.iana.org/TLD/tlds-alpha-by-domain.txt");
            var response = request.GetResponse();
            var stream = response.GetResponseStream();
            if (stream == null)
                return list;
            var reader = new StreamReader(stream);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (line.StartsWith("#"))
                    continue;
                list.Add(line.Trim());
            }
            return list;
        }
    }
}
