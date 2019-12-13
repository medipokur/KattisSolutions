using System;
using System.Collections.Generic;

namespace Star{
    public class Star{
        public static void Main(){
            int num = Convert.ToInt32(Console.ReadLine());
            
            List<string> result = new List<string>();
            result.Add(string.Format("{0}:", num));
            
            for (int i=2; i<=(num/2)+1; ++i){
                if (num % (i + i - 1) == 0 || (num - i) % (i + i - 1) == 0 ){
                    result.Add(string.Format("{0},{1}", i, i-1));
                }
                if (num % i == 0){
                    result.Add(string.Format("{0},{1}", i, i));
                }
            }
            
            foreach(string s in result){
                Console.WriteLine(s);
            }
        }   
    }
}
