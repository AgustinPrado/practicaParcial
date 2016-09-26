using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spaceAlumno;

namespace spaceCurso
{
    public class Curso
    {
        private string _descripcion;
        private Alumno[] _alumnos;
        private DateTime _fechaComienzo;

        public Curso()
        {
            this._alumnos = new Alumno[5];
        }

        public Curso(string descripcion, DateTime fechaComienzo)
            : this()
        {
            this._descripcion = descripcion;
            this._fechaComienzo = fechaComienzo;
        }

        public static bool operator + (Curso cur, Alumno alu)
        {
            int indice;

            if(!cur.ExisteAlumno(alu))
            {
                indice = cur.HayLugar();
                if(indice != -1)
                {
                    cur._alumnos[indice] = alu;
                    return true;
                }
            }
            return false;
        }

        private int HayLugar()
        {
            for (int i = 0; i < this._alumnos.Length; i++)
            {
                if (this._alumnos[i] == (object)null)
                    return i;
            }
            return -1; 
        }

        private bool ExisteAlumno(Alumno alumno)
        {
            for (int i = 0; i < this._alumnos.Length; i++)
            {
                if (this._alumnos[i] != (object)null)
                {
                    if (this._alumnos[i] == alumno)
                        return true;
                }
            }
            return false;
        }

        public string Info()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Descripción: " + this._descripcion + ", Fecha comienzo: " + this._fechaComienzo.ToShortDateString());

            for (int i = 0; i < this._alumnos.Length; i++)
            {
                if (this._alumnos[i] != (object)null)
                {
                    sb.AppendLine(this._alumnos[i].Info());
                }
            }

            return sb.ToString();
        }
    }
}
