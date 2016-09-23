using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial37_CuentaCorrienteBanco2011
{
    public class Usuario
    {
        private string _apellido;
        private string _nombre;
        private double _dni;
        public double Dni
        {
            get
            {
                return this._dni;
            }
        }

        public Usuario (string apellido, string nombre, double dni)
        {
            this._apellido = apellido;
            this._nombre = nombre;
            this._dni = dni;
        }

        private string DevolverDatosFormatoString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Nombre: " + this._nombre);
            sb.AppendLine("Apellido: " + this._apellido);
            sb.AppendLine("DNI: " + this.Dni);

            return sb.ToString();
        }

        public static string Mostrar(Usuario UsuarioActual)
        {
            return UsuarioActual.DevolverDatosFormatoString();
        }

    }
}
