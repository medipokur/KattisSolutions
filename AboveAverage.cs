using System;
using System.Collections.Generic;
using System.Linq;

namespace Aah
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTestCase = Convert.ToInt32(Console.ReadLine());

            List<string> abovePercentages = new List<string>();

            for (int i = 0; i < numTestCase; ++i)
            {
                string inputLine = Console.ReadLine();

                string[] inputs = inputLine.Split(' ');

                int numStudents = Convert.ToInt32(inputs[0]);

                List<int> grades = inputs.Skip(1).Select(p => Convert.ToInt32(p)).ToList();

                double avg = grades.Average();

                int aboveAvegareCount = grades.Count(p => p > avg);

                string percentage = ((decimal)aboveAvegareCount / numStudents).ToString("0.000%");

                abovePercentages.Add(percentage);
            }

            foreach (string str in abovePercentages)
            {
                Console.WriteLine(str);
            }
        }
    }
}
