using System;
using System.Linq;

namespace Kornislav{
    public class Kornislav{
        public static void Main(){
            string[] inputs = Console.ReadLine().Split(' ');
            
            int[] numbers = inputs.Select(p => Convert.ToInt32(p)).OrderBy(p => p).ToArray();
            
            Console.WriteLine(numbers[0] * numbers[2]);
        }
    }
}
