using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StartLeetCode
{
    public class LeetCode227
    {
        public int Calculate(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            } 

            var length = s.Length;
            var stack = new Stack<string>();

            int index = 0;
            var highOperator = false;

            while (index < length)
            {
                var current = s[index];
                if (char.IsWhiteSpace(current))
                {
                    index++;
                    continue;
                }

                if (current == '*' || current == '/' 
                                   || current == '+' || current == '-')
                {
                    stack.Push(current.ToString());
                    index++;

                    if (current == '*' || current == '/')
                    {
                        highOperator = true;
                    }
                }

                if (char.IsDigit(current))
                {
                    int start = index;
                    int end = index;


                    while (index < length && char.IsDigit(s[index]))
                    {
                        end = index;
                        index++;
                    }

                    var number = s.Substring(start, end - start+1);
                    stack.Push(number);
                    if (highOperator)
                    {
                        var number2 = Convert.ToInt32(stack.Pop());
                        var operator1 = stack.Pop();
                        var number1 = Convert.ToInt32(stack.Pop());

                        if (operator1[0] == '*')
                        {
                            stack.Push((number1*number2).ToString());
                        }
                        else
                        {
                            stack.Push((number1/number2).ToString());
                        }

                        highOperator = false;
                    }
                }
            }

            while (stack.Count > 0)
            {
                var unknown = stack.Pop();
                var isOperator = unknown.Length == 1 && (unknown[0] == '*' || unknown[0] == '/'
                                                                        || unknown[0] == '+' || unknown[0] == '-');
                if (! isOperator)
                {
                    var number2 = Convert.ToInt32(unknown);
                    if (stack.Count>1)
                    {
                        var operator1 = stack.Pop();
                        var number1 = Convert.ToInt32(stack.Pop());

                        if (stack.Count > 0 && stack.Peek().Length == 1 && stack.Peek()[0] == '-')
                        {
                            stack.Pop();
                            stack.Push("+");
                            number1 *= -1;
                        }

                        if (operator1[0] == '+')
                        {
                            stack.Push((number1+number2).ToString());
                        }

                        else if (operator1[0] == '-')
                        {
                            stack.Push((number1-number2).ToString());
                        }
                    }
                    else
                    {
                        return number2;
                    }
                }
            }

            return 0;
        }

        public int Calculate2(string s)
        {
            var stack = new Stack<string>();

            var numberStr = new StringBuilder();
            foreach (var c in s)
            {
                if (! char.IsWhiteSpace(c))
                {
                    if (char.IsDigit(c))
                    {
                        numberStr.Append(c);
                    }
                    else
                    {
                        Calculate(stack, numberStr.ToString());
                        numberStr = new StringBuilder();
                        stack.Push($"{c}");
                    }
                }
            }

            Calculate(stack, numberStr.ToString());

            var result = 0;

            while (stack.Any())
            {
                var curNumberStr = stack.Pop();
                if (stack.Any())
                {
                    var curSignStr = stack.Pop();
                    if (curSignStr == "-")
                    {
                        result += -int.Parse(curNumberStr);
                    }
                    else
                    {
                        result += int.Parse(curNumberStr);
                    }
                }
                else
                {
                    result += int.Parse(curNumberStr);
                }
            }

            return result;
        }

        private void Calculate(Stack<string> stack, string secondNumberStr)
        {
            if (stack.Any() && (stack.Peek() == "*" || stack.Peek() == "/"))
            {
                var sign = stack.Pop();
                var firstNumber = int.Parse(stack.Pop());
                var secondNumber = int.Parse(secondNumberStr);

                int result = 0;
                if (sign == "*")
                {
                    result = firstNumber * secondNumber;
                }

                if (sign == "/")
                {
                    result = firstNumber / secondNumber;
                }

                stack.Push($"{result}");
            }
            else
            {
                stack.Push(secondNumberStr);
            }
        }

        [Test]
        public void TestCalculate()
        {
            int Test(string s) => Calculate(s);

            Assert.That(Test("3+2*2+10"), Is.EqualTo(17));

        }
    }
}
