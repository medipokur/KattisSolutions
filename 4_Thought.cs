using System;
using System.Collections.Generic;
using System.Data;

namespace ConsoleApp2
{
    class Program
    {
        static readonly DataTable dataTable = new DataTable();

        static void Main(string[] args)
        {
            string operators = "+-*/";

            List<string> expressions = new List<string>();

            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int k = 0; k < 4; ++k)
                    {
                        expressions.Add("4" + operators[i] + "4" + operators[j] + "4" + operators[k] + "4");
                    } 
                }
            }

            Dictionary<int, string> expressionResults = new Dictionary<int, string>();

            foreach (string expression in expressions)
            {
                int expressionResult = EvaluateExpression(expression);
                if (!expressionResults.ContainsKey(expressionResult))
                {
                    expressionResults.Add(expressionResult, expression);
                }
            }

            int numCases = Convert.ToInt32(Console.ReadLine());

            List<int> testCases = new List<int>();

            for (int i= 0; i < numCases; ++i)
            {
                testCases.Add(Convert.ToInt32(Console.ReadLine()));
            }

            foreach (int testCase in testCases)
            {
                if (expressionResults.ContainsKey(testCase))
                {
                    Console.WriteLine(expressionResults[testCase]);
                }
                else
                {
                    Console.WriteLine("no solution");
                }
            }
        }
        
        static int EvaluateExpression(string expression)
        {
            // 4+4/4*4

            if ((expression[1] == '+' || expression[1] == '-') 
                && (expression[3] == '*' || expression[3] == '/'))
            {
                int middle = Evaluate(expression.Substring(2, 3));

                if (expression[5] == '*' || expression[5] == '/')
                {
                    int end = Evaluate(middle.ToString() + expression.Substring(5, 2));

                    return Evaluate(expression.Substring(0, 2) + end.ToString());
                }
                else
                {
                    int start = Evaluate(expression.Substring(0, 2) + middle.ToString());

                    return Evaluate(start.ToString() + expression.Substring(5, 2));
                }
            }
            else
            {

            }            
        }

        static int Evaluate(string expr)
        {
            // 166*16
            int index = expr.IndexOfAny(new char[] { '+', '-', '*', '\\' });

            int leftSide = Convert.ToInt32(expr.Substring(0, index));

            int rightSide = Convert.ToInt32(expr.Substring(index+1, expr.Length-index-1));

            if (expr[index] == '+')
            {
                return leftSide + rightSide;
            }
            else if (expr[index] == '-')
            {
                return leftSide - rightSide;
            }
            else if (expr[index] == '*')
            {
                return leftSide * rightSide;
            }
            else
            {
                return leftSide / rightSide;
            }
        }
        
        static int EvaluateExpressionOld(string expression)
        {
            return Convert.ToInt32(dataTable.Compute(expression, null));
        }
    }
}
