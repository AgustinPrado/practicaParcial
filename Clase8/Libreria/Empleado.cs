using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    public class Empleado : Persona
    {
        private string _legajo;
        private EPuestoJerarquico _puesto;
        private int _salario; 

        public Empleado(string nombre, string apellido, string legajo, EPuestoJerarquico puesto, int salario)
            : base(nombre, apellido)
        {
            this._legajo = legajo;
            this._puesto = puesto;
            this._salario = salario;
        }

        public Empleado(Persona persona, string legajo, EPuestoJerarquico puesto, int salario)
            : this(persona.Nombre, persona.Apellido, legajo, puesto, salario)
        {

        }

        public static bool operator == (Empleado empUno, Empleado empDos)
        {
            if(!object.ReferenceEquals(empUno, null) && !object.ReferenceEquals(empDos, null))
            {
                if (empUno._legajo == empDos._legajo)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Empleado empUno, Empleado empDos)
        {
            return !(empUno == empDos);
        }

        private string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(Persona.Mostrar(this));
            sb.AppendLine("LEGAJO: " + this._legajo);
            sb.AppendLine("SALARIO: $" + this._salario);
            sb.AppendLine(this.PosicionSocietaria());

            return sb.ToString();
        }

        public override string PosicionSocietaria()
        {
            return "Empleado de " + this._puesto.ToString();
        }

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
