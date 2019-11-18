using System;

namespace Planina{
    
    public class Planina{
        public static void Main(){
            int iteration = Convert.ToInt32(Console.ReadLine());
            // iteration 1 = Math.Pow(2,0) = 1 square
            Console.WriteLine(Math.Pow(Math.Pow(2, iteration)+1,2));
        }
    }
}
