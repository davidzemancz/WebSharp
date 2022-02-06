using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSharp.Data;
using WebSharp.Helpers;
using WebSharp.Primitives;

namespace WebSharp.Html
{
    public class Page
    {
        private TextReader _reader;
        private TextWriter _writer;
        private IDataProvider _dataProvider;

        public Page(TextReader reader, TextWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public void Build(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            while (true)
            {
                int i = _reader.Read();
                if (i == -1) break;
                char c = (char)i;

                if (c == '$')
                {
                    if (_reader.Peek() == '{')
                    {
                        BuildBlock();
                    }
                    else
                    {
                        BuildExpression();
                    }
                }
                else _writer.Write(c);
            }
        }

        private void BuildBlock()
        {
            throw new NotImplementedException();
        }

        private void BuildExpression()
        {
            string expression = "";
            
            while (true)
            {
                int i = _reader.Read();
                if (i == -1) break;
                char c = (char)i;

                bool isParentheses = HChar.IsParentheses(c);
                bool isBrackets = HChar.IsBrackets(c);
                bool isOperator = HChar.IsOperator(c);

                if (char.IsLetterOrDigit(c) || isParentheses || isBrackets || isOperator)
                {
                    expression += c;
                }
                else
                {
                    object result = new Expression(expression, _dataProvider).Evaluate();
                    if (result != null) _writer.Write(result);
                    _writer.Write(c);
                    break;
                }
            }
        }
    }
}
