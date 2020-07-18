using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
namespace CsharpAgeCounting
{
    class Program
    {
        static void Main(string[] args)
        {
            var route = "https://coderbyte.com/api/challenges/json/age-counting";
            WebRequest request = WebRequest.Create(route);
            WebResponse response = request.GetResponse();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                string data = reader.ReadToEnd();
                Console.WriteLine(GetValue(data));
                response.Close();
            }
          
            Console.ReadKey();
        }
        public static int GetValue(string data)
        {
            var count = 0;
            var regexp = new Regex("age=(?<age>[0-9]+)", RegexOptions.Singleline);
            foreach (Match matches in regexp.Matches(data))
            {
                var age = int.Parse(matches.Groups["age"].Value);
                if (age >= 50)
                {
                    count++;
                }

            }
            return count;
        }
    }
}
