using System.Numerics;
using DataStructures;

namespace Calculator
{
    /// Best data structure:
    /// stack: because it is the best for undo operations.
    /// </summary>
    public class CalculatorProblem
    {
        private readonly CustomStack<char> _operationStack = new();
        private bool _operationExistInStack = false;

        private char _operatorChar;

        public void EnterNumber(char num)
        {
            _operationStack.Push(num);
        }

        public void TypeOperation(char op)
        {
            if (!_operationExistInStack)
            {
                _operationStack.Push(op);
                _operationExistInStack = true;
            }
        }

        public void Undo()
        {
            if (_operationStack.Count > 0)
            {
                char value = _operationStack.Pop();
                if (itsOperation(value))
                { 
                    _operationExistInStack = false;
                }                
            }
        }

        public int Evaluate()
        {
            if (!itsOperation(_operationStack.Peek()) && _operationExistInStack)
            {
                String expression = _operationStack.ToArray().ToString();
                String exp1 = expression.Substring(0, expression.IndexOf(_operatorChar));
                String exp2 = expression.Substring(expression.IndexOf(_operatorChar));
                int num1 = int.Parse(exp1);
                int num2 = int.Parse(exp2);
                return Operate(num1, num2);
            }
            else
            {
                return 0;
            }
        }

        private int Operate(int num1, int num2)
        {
            int result;
            if (_operatorChar == '+')
            {
                return num1 + num2;
            }
            if (_operatorChar == '-')
            {
                return num1 - num2;
            }
            if (_operatorChar == '*')
            {
                return num1 * num2;
            }
            else
            {
                return num1 / num2;
            }
        }

        private bool itsOperation(char c)
        {
            if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                _operatorChar = c;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}