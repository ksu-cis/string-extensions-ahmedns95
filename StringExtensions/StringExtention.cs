using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtention
    {
        // part of the class if it self since it is static
        public static int WordCount(this string str)
        {
            return str.Split(new char[] { ' ', '.','?','\t','n' }, StringSplitOptions ).Length;
        }

        public static string Captalize(this string str)
        {
            string first = str[0].ToString().ToUpper();
            return first + str.ToString();
        }
        public static string DeCaptalize(this string str)
        {
            //This DOES NOT WORK!! 
            string first = str[0].ToString().ToLower();
            return first + str.Substring(1);
        }

        public static string Titleize (this string title)
        {
            List<string> articles = new List<string>()
            {
                "a",
                "and",
                "the"
            };

            List<string> parts = new List<string>(title.Split(" "));
            string first = parts[0];
            if (articles.Contains(parts[0].ToLower()))
            {
                parts.RemoveAt(0);
                parts.Add(", "+ first);
                parts.Add(first);
                first = parts[0];
                while (articles.Contains(first.ToLower()))
                {
                    parts.RemoveAt(0);
                    parts.Add(first);
                    first = parts[0];
                }
                
            }
            string result = "";
            foreach (string part in parts)
            {
                result += part + " ";
            }
            return result;
        }
    }
}
