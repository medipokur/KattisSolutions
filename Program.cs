using System;
using System.Collections.Generic;
using System.Text;

namespace Aah
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputList = new List<string>();

            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                inputList.Add(inputLine);
            }

            foreach (string line in inputList)
            {
                Console.WriteLine(ConvertLine(line));
            }
        }

        static string ConvertLine(string line)
        {
            string[] words = line.Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (string word in words)
            {
                sb.Append(ConvertWord(word) + " ");
            }

            return sb.ToString().TrimEnd();
        }

        static string ConvertWord(string word)
        {
            string vowels = "aeiouy";
            if (vowels.IndexOf(word[0]) != -1)
            {
                return word + "yay";
            }
            else
            {
                int vowelIndex = word.IndexOfAny(vowels.ToCharArray());
                return word.Substring(vowelIndex) + word.Substring(0, vowelIndex) + "ay";
            }
        }
    }
}
