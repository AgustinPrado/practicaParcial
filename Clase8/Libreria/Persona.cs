using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public abstract class Persona
    {
        protected string _nombre;
        protected string _apellido;

        public string Nombre
        {
            get { return this._nombre; }
        }
        public string Apellido
        {
            get { return this._apellido; }
        }

        public Persona(string nombre, string apellido)
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public abstract string PosicionSocietaria();

        protected static string Mostrar(Persona p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("NOMBRE: " + p.Nombre);
            sb.AppendLine("APELLIDO: " + p.Apellido);

            return sb.ToString();
        }
    }
}
