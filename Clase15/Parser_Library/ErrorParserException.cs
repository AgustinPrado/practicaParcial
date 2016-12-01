using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_Library
{
    public class ErrorParserException : Exception
    {
        public ErrorParserException(string message, Exception e)
            : base(message, e)
        {

        }
    }
}
