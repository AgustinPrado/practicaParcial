using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcialHabemusPapa
{
    public class Conclave
    {
        private int _cantMaxCardenales;
        private List<Cardenal> _cardenales;
        private bool _habemusPapa;
        private string _lugarEleccion;
        private Cardenal _papa;
        public static int cantidadVotaciones;
        public static DateTime fechaVotacion;
        public static Random objRandom;

        static Conclave()
        {
            Conclave.cantidadVotaciones = 0;
            Conclave.fechaVotacion = DateTime.Now;
            Conclave.objRandom = new Random();
        }

        private Conclave()
        {
            this._cantMaxCardenales = 1;
            this._lugarEleccion = "Capilla Sixtina";
            this._habemusPapa = false;
            this._cardenales = new List<Cardenal>();
            Conclave.cantidadVotaciones = 0;
        }

        private Conclave(int cantidadCardenales)
            : this()
        {
            this._cantMaxCardenales = cantidadCardenales;
        }

        public Conclave(int cantidadCardenales, string lugarEleccion)
            : this(cantidadCardenales)
        {
            // El lugar no lo cambio porque el ejercicio pide eso.
        }

        public static implicit operator Conclave(int cantidadCardenales)
        {
            return new Conclave(cantidadCardenales);
        }

        public static explicit operator bool(Conclave con)
        {
            return con._habemusPapa;
        }

        public static bool operator ==(Conclave con, Cardenal c)
        {
            foreach (Cardenal item in con._cardenales)
            {
                if (item == c)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Conclave con, Cardenal c)
        {
            return !(con == c);
        }

        public static Conclave operator +(Conclave con, Cardenal c)
        {
            if (con.HayLugar())
            {
                if (con != c)
                    con._cardenales.Add(c);
                else
                    Console.WriteLine("El cardenal ya está en el Cónclave!!!");
            }
            else
                Console.WriteLine("No hay más lugar!!!");
            return con;
        }

        private bool HayLugar()
        {
            return (this._cantMaxCardenales > this._cardenales.Count);
        }

        public static void VotarPapa(Conclave con)
        {
            int indicePapal;

            for (int i = 0; i < con._cardenales.Count; i++)
            {
                indicePapal = Conclave.objRandom.Next(0, con._cardenales.Count);
                con._cardenales[indicePapal]++;
            }

            Conclave.ContarVotos(con);
        }

        private static void ContarVotos(Conclave conclave)
        {
            int maxVotos = 0;
            int cantMaxVotos = 0;
            int indiceMaxVotos = 0;

            foreach (Cardenal item in conclave._cardenales)
            {
                if (item.getCantidadVotosRecibidos() > maxVotos)
                    maxVotos = item.getCantidadVotosRecibidos();
            }
            foreach (Cardenal item in conclave._cardenales)
            {
                if (item.getCantidadVotosRecibidos() == maxVotos)
                {
                    cantMaxVotos++;
                    indiceMaxVotos = conclave._cardenales.IndexOf(item);
                }
            }

            if (cantMaxVotos == 1)
            {
                conclave._papa = conclave._cardenales[indiceMaxVotos];
                conclave._habemusPapa = true;
            }
            else
            {
                conclave._habemusPapa = false;
            }
        }

        private string MostrarCardenales()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Cardenales:\n");

            foreach (Cardenal item in this._cardenales)
            {
                sb.AppendLine(Cardenal.Mostrar(item));
            }

            return sb.ToString();
        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\nLugar de la elección: " + this._lugarEleccion);
            sb.AppendLine("Fecha: " + Conclave.fechaVotacion.ToShortDateString());
            sb.AppendLine("Cantidad de votaciones: " + Conclave.cantidadVotaciones);

            if (this._habemusPapa)
            {
                sb.AppendLine("HABEMUS PAPA!!!!\n");
                sb.AppendLine(this._papa.ObtenerNombreYNombrePapal());
            }
            else
            {
                sb.AppendLine("NO HABEMUS PAPA!!!!\n");
                sb.AppendLine(this.MostrarCardenales());
            }

            return sb.ToString();
        }
    }
}
