using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using spaceAlumno;
using spaceCurso;

namespace parcial40_AlumnoCursoArray2012
{
    class Program
    {
        static void Main(string[] args)
        {
            int valor = 6;
            Alumno alumno1 = new Alumno(1, "alumno1");
            Alumno alumno2 = new Alumno(2, "alumno2");
            Alumno alumno3 = new Alumno(3, "alumno3");
            Alumno alumno4 = new Alumno(1, "alumno4");
            Alumno alumno5 = new Alumno(4, "alumno5");
            Alumno alumno6 = new Alumno(5, "alumno6");
            Alumno alumno7 = new Alumno(6, "alumno7");
            Alumno alumno8 = valor;

            Curso curso = new Curso("Curso", new DateTime(2012, 1, 1));

            bool retorno;
            retorno = curso + alumno1;
            retorno = curso + alumno2;
            retorno = curso + alumno3;
            retorno = curso + alumno4;
            retorno = curso + alumno5;
            retorno = curso + alumno6;
            retorno = curso + alumno7;
            retorno = curso + alumno8;

            Console.WriteLine(curso.Info());

            Console.ReadKey();
        }
    }
}
