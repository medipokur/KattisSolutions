using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KattisUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine;
            int unitCount;
            List<string> unitNames;
            List<Unit> units;
            List<Equation> equations;

            while ((firstLine = Console.ReadLine()) != "0")
            {
                unitCount = Convert.ToInt32(firstLine);

                unitNames = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None).ToList();

                equations = new List<Equation>();

                units = new List<Unit>();

                foreach (string unitName in unitNames)
                {
                    units.Add(new Unit() { UnitName = unitName });
                }

                for (int i = 1; i < unitCount; ++i)
                {
                    string[] conversionData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.None);

                    equations.Add(new Equation()
                    {
                        LeftUnit = conversionData[0],
                        Factor = Convert.ToInt32(conversionData[2]),
                        RightUnit = conversionData[3]
                    });
                }

                bool isUpdated = false;

                while (units.Count(p => p.UnitValue == 1) > 1 || isUpdated)
                {
                    isUpdated = false;

                    foreach (Equation equation in equations)
                    {
                        Unit leftUnit = units.First(p => p.UnitName == equation.LeftUnit);
                        Unit rightUnit = units.First(p => p.UnitName == equation.RightUnit);
                        int newLeftValue = rightUnit.UnitValue * equation.Factor;

                        if (newLeftValue > leftUnit.UnitValue)
                        {
                            leftUnit.UnitValue = newLeftValue;
                            isUpdated = true;
                        }

                        int newRightValue = leftUnit.UnitValue / equation.Factor;

                        if (newRightValue > rightUnit.UnitValue)
                        {
                            rightUnit.UnitValue = newRightValue;
                            isUpdated = true;
                        }
                    }
                }

                units = units.OrderByDescending(p => p.UnitValue).ToList();

                string result = "1" + units[0].UnitName;

                for (int i = 1; i < units.Count; ++i)
                {
                    int factor = units[0].UnitValue / units[i].UnitValue;

                    result += " = " + factor.ToString() + units[i].UnitName;
                }

                Console.WriteLine(result);
            }
        }
    }

    public class Unit
    {
        public string UnitName { get; set; }

        public int UnitValue { get; set; } = 1;
    }

    public class Equation
    {
        public string LeftUnit { get; set; }

        public string RightUnit { get; set; }

        public int Factor { get; set; }
    }
}
