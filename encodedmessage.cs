using System;

namespace Encoded{
    public class Encoded{
        public static void Main(){
            int numCases = Convert.ToInt32(Console.ReadLine());
            string[] decodedList = new string[numCases]; 
            for (int i=0; i<numCases; ++i){
                string input = Console.ReadLine();
                decodedList[i] = DecodeMessage(input);
            }
            
            foreach(string decoded in decodedList){
                Console.WriteLine(decoded);
            }
        }
        public static string DecodeMessage(string input){
            
            int length = (int)Math.Sqrt(input.Length);
            
            string output = "";
            
            for (int i=1; i<=length; ++i){
                for(int j=length-i; j<input.Length; j=j+length){
                    output += input[j];
                }
            }
            
            return output;
        }
    }
}
