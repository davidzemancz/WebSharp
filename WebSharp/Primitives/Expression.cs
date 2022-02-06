using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSharp.Data;
using WebSharp.Helpers;

namespace WebSharp.Primitives
{
    public class Expression
    {
        private int _pos;
        private string _expression;
        private IDataProvider _dataProvider;

        public Expression(string expression, IDataProvider dataProvider)
        {
            _expression = expression;
            _dataProvider = dataProvider;
            _pos = 0;
        }

        public object Evaluate()
        {
            object result = null;
            if (IsAsignment(out string target))
            {
                result = Evaluate();
                _dataProvider.SetValue(target, result);
            }
            else
            {
                result = _expression.Substring(_pos);
            }
            return result;
        }

        private bool IsAsignment(out string target)
        {
            bool result = false;
            int i = _pos;
            if (!char.IsLetter(_expression[i++])) result = false;
            else 
            {
                for (;i < _expression.Length; i++)
                {
                    if (!char.IsLetterOrDigit(_expression[i]))
                    {
                        if (HString.Equals(Operators.Asignment, _expression[i]))
                        {
                            if (i < _expression.Length - 1 && HString.Equals(Operators.Equality, _expression[i], _expression[i + 1])) result = false;
                            else result = true;
                        }
                        break;
                    }
                }
            }
            if (result)
            {
                _pos = i + Operators.Asignment.Length;
                target = _expression.Substring(0, i);
            }
            else target = null;
            return result;
        }
    }
}
