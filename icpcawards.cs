using System;
using System.Collections.Generic;

namespace Awars{
    public class Awards{
        public static void Main(){
            int count = Convert.ToInt32(Console.ReadLine());
            Dictionary<string,string> resultList = new Dictionary<string,string>();
            for (int i = 0; i<count && resultList.Count < 12; ++i){
                string[] inputs = Console.ReadLine().Split(' ');
                    
                if (!resultList.ContainsKey(inputs[0])){
                    resultList.Add(inputs[0], inputs[1]);
                }
            }
            
            foreach(KeyValuePair<string, string> entry in resultList){
                Console.WriteLine(entry.Key + " " + entry.Value);
            }
        }
    }
}
