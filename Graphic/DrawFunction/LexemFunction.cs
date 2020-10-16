using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Build;
using System.Threading.Tasks;

namespace Graphic.DrawFunction
{
    class LexemFunction
    {
        static int current;
        static string func;
        public static void Function(string func)
        {

        }

        public static void NextLexem()
        {
            switch (func[current])
            {
                case '+':
                    break;
                case '-':
                    break;
                case 'x':
                    break;
                case '*':
                    break;
                case '/':
                    break;
                default:
                    if (new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9', '0' }.Contains(func[current]))
                    {

                    }
                    break;
            }
        }

        enum Lexem
        {
            number,
            parametrX,
            plus,
            minus,
            mult,
            div
        }
    }
}
