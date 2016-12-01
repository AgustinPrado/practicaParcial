using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser_Library
{
    public static class Parser
    {
        static string messageCatch;

        static Parser()
        {
            messageCatch = "El string no podrá ser convertido";
        }

        public static bool TryParse(string cadena, out int numero)
        {
            int aux;
            try
            {
                aux = Parser.Parse(cadena);
                numero = aux;
                return true;
            }
            catch (Exception)
            {
                numero = 0;
                return false;
            }
        }

        public static int Parse(string cadena)
        {
            try
            {
                return int.Parse(cadena);
            }
            catch (FormatException e)
            {
                throw new ErrorParserException(messageCatch + " por error de formato", e);
            }
            catch (OverflowException e)
            {
                throw new ErrorParserException(messageCatch + " por tamaño del dato", e);
            }
            catch (Exception e)
            {
                throw new ErrorParserException(messageCatch, e);
            }
        }
    }
}
