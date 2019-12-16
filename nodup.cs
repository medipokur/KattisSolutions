using System;
using System.Linq;

namespace NoDuplicates{
    public class NoDuplicates{
        public static void Main(){
            string[] inputs = Console.ReadLine().Split(' ');
            var query = inputs.GroupBy(p => p).Where(x => x.Count() > 1);
            if (query.Any()){
                Console.WriteLine("no");
            }
            else {
                Console.WriteLine("yes");
            }
        }
    }
}
