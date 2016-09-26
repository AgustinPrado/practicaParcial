using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spaceAlumno
{
    public class Alumno
    {
        private string _apellido;
        private string _nombre;
        private string _dni;
        private int _legajo;

        public string Info()
        {
            return ("Legajo: " + _legajo + ", Apellido: " + _apellido + ", Nombre: " + _nombre + ", DNI: " + _dni);
        }

        public Alumno(int legajo, string apellido)
        {
            this._legajo = legajo;
            this._apellido = apellido;
        }

        public Alumno(int legajo, string apellido, string nombre)
            : this(legajo, apellido)
        {
            this._nombre = nombre;
        }

        public Alumno(int legajo, string apellido, string nombre, string dni)
            : this(legajo, apellido, nombre)
        {
            this._dni = dni;
        }

        public static bool operator == (Alumno alu1, Alumno alu2)
        {
            return (alu1._legajo == alu2._legajo);
        }

        public static bool operator != (Alumno alu1, Alumno alu2)
        {
            return !(alu1 == alu2);
        }

        public static implicit operator Alumno (int legajo)
        {
            return new Alumno(legajo, "SIN APELLIDO");
        }
    }
}
