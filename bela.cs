using System;
using System.Collections.Generic;

namespace Bela{
    public class Bela{
        public static void Main(){
            int total = 0;
            var domValues = new Dictionary<char, int>{
                {'A', 11}, {'K', 4}, {'Q', 3}, {'J', 20}, 
                {'T', 10}, {'9', 14}, {'8', 0}, {'7', 0}
            };
            
            var nonValues = new Dictionary<char, int>{
                {'A', 11}, {'K', 4}, {'Q', 3}, {'J', 2}, 
                {'T', 10}, {'9', 0}, {'8', 0}, {'7', 0}
            };
            
            string[] inputs = Console.ReadLine().Split(' ');
            int numHands = Convert.ToInt32(inputs[0]);
            char dominantSuit = inputs[1][0];
            for (int i=0; i<4*numHands; ++i){
                string input = Console.ReadLine();
                if (input[1] == dominantSuit){
                    total += domValues[input[0]];
                }
                else {
                    total += nonValues[input[0]];
                }
            }
            Console.WriteLine(total);
        }
    }
}