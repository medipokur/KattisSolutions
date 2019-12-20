using System;
using System.Collections.Generic;
using System.Linq;

namespace Gerry{
    public class Gerry{
        public static void Main(){
            string[] inputs = Console.ReadLine().Split(' ');
            
            int numEntries = Convert.ToInt32(inputs[0]);
            
            Dictionary<int, List<int>> voteResults = new Dictionary<int, List<int>>();
            int totalVotes = 0;
            for (int i=0; i<numEntries; ++i){
                string[] entries = Console.ReadLine().Split(' ');
                
                int districtId = Convert.ToInt32(entries[0]);
                int aVotes = Convert.ToInt32(entries[1]);
                int bVotes = Convert.ToInt32(entries[2]);
                
                if (voteResults.ContainsKey(districtId)){
                    List<int> voteCounts = voteResults[districtId];
                    voteCounts[0] += aVotes;
                    voteCounts[1] += bVotes;
                }
                else {
                    voteResults.Add(districtId, new List<int>{aVotes, bVotes});
                }
                totalVotes += aVotes + bVotes;
            }
            
            List<KeyValuePair<string, List<int>>> resultList = new List<KeyValuePair<string, List<int>>>();
            int aLostTotal = 0, bLostTotal = 0;
            foreach (KeyValuePair<int, List<int>> entry in voteResults.OrderBy(p => p.Key)){
                List<int> districtResults = entry.Value;
                string winner = districtResults[0] > districtResults[1] ? "A" : "B";
                int total = districtResults[0] + districtResults[1];
                int enoughVotes = (total / 2) + 1;
                int aLost, bLost;
                if (winner == "A"){
                    aLost = districtResults[0] - enoughVotes;
                    bLost = districtResults[1];
                }
                else {
                    bLost = districtResults[1] - enoughVotes;
                    aLost = districtResults[0];
                }
                aLostTotal += aLost;
                bLostTotal += bLost;
                var result = new KeyValuePair<string, List<int>>(winner, new List<int>{aLost, bLost});
                resultList.Add(result);
            }
            
            foreach (KeyValuePair<string, List<int>> entry in resultList){
                Console.WriteLine(string.Format("{0} {1} {2}", entry.Key, entry.Value[0], entry.Value[1]));
            }
            
            Console.WriteLine(Math.Abs(aLostTotal-bLostTotal) / (double)(totalVotes));
        }
    }
}
