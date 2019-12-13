using System;
using System.Linq;

namespace Parking{
    public class Parking{
        public static void Main(){
            int numCases = Convert.ToInt32(Console.ReadLine());
            int[] results = new int[numCases];
            
            for (int i=0; i<numCases; ++i){
                Console.ReadLine();
                string[] inputs = Console.ReadLine().Split(' ');
                
                int max = inputs.Max(p => Convert.ToInt32(p));
                int min = inputs.Min(p => Convert.ToInt32(p));
                
                results[i] = (max - min) * 2;
            }
            
            foreach(int i in results){
                Console.WriteLine(i);
            }
        }
    }
}
