using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace Algorithms
{
    public class ExpressionTrees
    {
        public bool IsProperlyNested(string expresstion)
        {
            int parenthesesCounter = 0;
            for (int i = 0; i < expresstion.Length; i++)
            {
                if (expresstion[i] == '(')
                    parenthesesCounter++;
                else if (expresstion[i] == ')')
                {
                    parenthesesCounter--;
                    if (parenthesesCounter < 0) return false;
                }
            }

            return parenthesesCounter == 0;
        }

        public float EvaluateExp(string exp)
        {
            if (!IsProperlyNested(exp))
                return float.NaN;
            return Evaluate(exp, 0);
        }

        public float Evaluate(string exp, int index)
        {
            if (IsOutOfBounds(index, exp))
                return 0;

            float literal = 0;
            if (IsNumber(exp[index]))
            {
                string strLiteral = string.Empty;
                while (IsNumber(exp[index]))
                {
                    strLiteral += exp[index];
                    index++;
                    if (IsExceedLenght(index, exp))
                    {
                        return float.Parse(strLiteral, CultureInfo.InvariantCulture);
                    }
                }

                literal = float.Parse(strLiteral, CultureInfo.InvariantCulture);
            }else if (exp[index] == '(')
            {
                var closeBracketIndex = exp.LastIndexOf(')');
                literal = Evaluate(exp.Substring(++index, (closeBracketIndex - index)), 0);
                index = closeBracketIndex + 1;
                if (IsExceedLenght(index, exp))
                {
                    return literal;
                }
            }

            switch (exp[index])
            {
                case '/':
                    return literal / Evaluate(exp, ++index);
                case '*':
                    return literal * Evaluate(exp, ++index);
                case '+':
                    return literal + Evaluate(exp, ++index);
                case '-':
                    return literal - Evaluate(exp, ++index);                
            }

            return literal;
        }        

        private bool IsNumber(char value)
        {
            return (value >= '0' && value <= '9') || value == '.';
        }
        private bool IsExceedLenght(int index, string exp)
        {
            return index > exp.Length - 1;
        }

        private bool IsOutOfBounds(int index, string exp)
        {
            return index > exp.Length - 1 || index < 0;
        }

        private int SkipBlankChars(int index, string value)
        {
            int tmpIndex = index;
            while (value[tmpIndex] == ' ')
            {
                tmpIndex++;
                if (IsExceedLenght(tmpIndex, value))
                {
                    return --tmpIndex;
                }
            }

            return tmpIndex;
        }
    }


}
