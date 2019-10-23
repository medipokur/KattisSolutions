using System;
using System.Collections.Generic;

namespace AmazingCannonball {
    
    class Amazing{
        
        static List<string> results = new List<string>();
        static double g = 9.81;
        static void Main(){
            
            int numCases = Convert.ToInt32(Console.ReadLine());
            
            for (int i=0; i<numCases; ++i){
                
                Solve();
            }
            for (int i=0; i<numCases; ++i){
		        Console.WriteLine(results[i]);
	        }
        }
        static void Solve(){
            string line = Console.ReadLine();
    string[] inputs = line.Split(' ');
            
    double v0 = Convert.ToDouble(inputs[0]);
    double angle = Convert.ToDouble(inputs[1]);
	double x1 = Convert.ToDouble(inputs[2]);
	double h1 = Convert.ToDouble(inputs[3]);
	double h2 = Convert.ToDouble(inputs[4]);
	
	// x = v0 * t * cos(angle)
	double time = x1 / (v0 * Math.Cos(angle  * (Math.PI / 180.0)));
	
	// y = v0 * t * sin(angle) − (1/2 * g * t2)
	double y = (v0 * time * Math.Sin(angle  * (Math.PI / 180.0))) - (0.5 * g * time * time);
	
	if (y > h1 + 1 && y < h2 - 1){
		results.Add("Safe");
	}
	else {
		results.Add("Not Safe");
	}
            
        }
    }
    
}