using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial39_FabricaOperarioArray
{
    public class Operario
    {
        private string _apellido;
        private string _nombre;
        private int _legajo;
        private float _salario;

        public Operario()
        {
            this._salario = 1500;
        }

        public Operario(string nombre, string apellido)
            : this()
        {
            this._nombre = nombre;
            this._apellido = apellido;
        }

        public Operario(string nombre, string apellido, int legajo)
            :this (nombre, apellido)
        {
            this._legajo = legajo;
        }

        public static bool operator == (Operario op1, Operario op2)
        {
            if(String.Compare(op1._apellido, op2._apellido) == 0)
            {
                if(String.Compare(op1._nombre, op2._nombre) == 0)
                {
                    if (op1._legajo == op2._legajo)
                        return true;
                }
            }
            return false;
        }

        public static bool operator !=(Operario op1, Operario op2)
        {
            return !(op1 == op2);
        }

        public float getSalario()
        {
            return this._salario;
        }

        public void setAumentarSalario(float aumento)
        {
            this._salario *= (1 + (aumento / 100));
        }

        public string ObtenerNombreYApellido()
        {
            StringBuilder sb = new StringBuilder(this._nombre + ", " + this._apellido);
            return sb.ToString();
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ObtenerNombreYApellido());
            sb.AppendLine("Legajo: " + this._legajo);
            sb.AppendLine("Salario: " + this.getSalario());
            return sb.ToString();
        }

        public static string Mostrar(Operario op)
        {
            return op.Mostrar();
        }
    }
}
