using System;

namespace Harshad{
    public class Harshad{
        public static void Main(){
            int num = Convert.ToInt32(Console.ReadLine());
            
            while (num % GetTotal(num) != 0){
                ++num;
            }
            
            Console.WriteLine(num);
        }
        
        public static int GetTotal(int num){
            int total = 0;
            
            while (num > 0){
                total += num % 10;
                num /= 10;
            }
            
            return total;
        }
    }
}
