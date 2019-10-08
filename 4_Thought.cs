using System;
using System.Collections.Generic;
//using System.Data;

namespace Aah
{
    class Program
    {
        //static readonly DataTable dataTable = new DataTable();

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

            for (int i = 0; i < numCases; ++i)
            {
                testCases.Add(Convert.ToInt32(Console.ReadLine()));
            }

            foreach (int testCase in testCases)
            {
                if (expressionResults.ContainsKey(testCase))
                {
                    string expression = expressionResults[testCase];
                    string spacedExpression = "";

                    foreach (char c in expression)
                    {
                        spacedExpression += c + " ";
                    }

                    spacedExpression = spacedExpression + "= " + testCase.ToString();

                    Console.WriteLine(spacedExpression);
                }
                else
                {
                    Console.WriteLine("no solution");
                }
            }
        }

        static int EvaluateExpression(string expression)
        {
            if ((expression[1] == '+' || expression[1] == '-')
                && (expression[3] == '*' || expression[3] == '/'))
            {
                int middle = Evaluate(expression.Substring(2, 3));

                if (expression[5] == '*' || expression[5] == '/')
                {
                    // 4+4/4*4

                    int end = Evaluate(middle.ToString() + expression.Substring(5, 2));

                    return Evaluate(expression.Substring(0, 2) + end.ToString());
                }
                else
                {
                    // 4+4/4-4

                    int start = Evaluate(expression.Substring(0, 2) + middle.ToString());

                    return Evaluate(start.ToString() + expression.Substring(5, 2));
                }
            }
            else if ((expression[1] == '+' || expression[1] == '-')
                && (expression[5] == '*' || expression[5] == '/'))
            {
                // 4+4+4*4
                int end = Evaluate(expression.Substring(4, 3));
                int start = Evaluate(expression.Substring(0, 3));

                return Evaluate(start.ToString() + expression[3] + end.ToString());
            }
            else if ((expression[1] == '*' || expression[1] == '/')
                && (expression[3] == '+' || expression[3] == '-')
                && (expression[5] == '*' || expression[5] == '/'))
            {
                // 4 * 4 + 4 / 4
                int start = Evaluate(expression.Substring(0, 3));
                int end = Evaluate(expression.Substring(4, 3));

                return Evaluate(start.ToString() + expression[3] + end.ToString());
            }
            else
            {
                // 4 + 4 + 4 + 4
                // 4 * 4 * 4 - 4
                int start = Evaluate(expression.Substring(0, 3));
                int middle = Evaluate(start.ToString() + expression.Substring(3, 2));

                return Evaluate(middle.ToString() + expression.Substring(5, 2));
            }
        }

        static int Evaluate(string expr)
        {
            int factor = 1;

            if (expr[0] == '-')
            {
                factor = -1;
                expr = expr.Substring(1);
            }

            // 166*16
            int index = expr.IndexOfAny(new char[] { '+', '-', '*', '/' });

            int leftSide = factor * Convert.ToInt32(expr.Substring(0, index));

            int rightSide = Convert.ToInt32(expr.Substring(index + 1, expr.Length - index - 1));

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
            //return Convert.ToInt32(dataTable.Compute(expression, null));
            return 0;
        }
    }
}
