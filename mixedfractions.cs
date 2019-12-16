using System;
using System.Collections.Generic;

namespace Mixed {
    public class Mixed {
        public static void Main(){
            List<string> results = new List<string>();
            string input;
            
            while ((input = Console.ReadLine()) != "0 0"){
                string[] inputs = input.Split(' ');
                int num1 = Convert.ToInt32(inputs[0]);
                int num2 = Convert.ToInt32(inputs[1]);
                
                int wholeNum = num1 / num2;
                int numerator = num1 - wholeNum * num2;
                results.Add(string.Format("{0} {1} / {2}", wholeNum, numerator, num2));
            }
            
            foreach (string s in results){
                Console.WriteLine(s);
            }
        }
    }
}
