using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Estante
    {
        protected sbyte _capacidad;
        protected List<Producto> _productos;

        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public static string MostrarEstante(Estante est)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Producto item in est._productos)
            {
                if (item is Jugo)
                    sb.AppendLine(((Jugo)item).MostrarJugo());
                if (item is Galletita)
                    sb.AppendLine(Galletita.MostrarGalletita((Galletita)item));
                if (item is Gaseosa)
                    sb.AppendLine(((Gaseosa)item).MostrarGaseosa());
            }

            return sb.ToString();
        }

        public static bool operator == (Estante est, Producto prod)
        {
            foreach (Producto item in est._productos)
            {
                if (item == prod)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Estante est, Producto prod)
        {
            return !(est == prod);
        }

        public static bool operator +(Estante est, Producto prod)
        {
            if(est._productos.Count < est._capacidad)
            {
                if(!(est == prod))
                {
                    est._productos.Add(prod);
                    return true;
                }
            }
            return false;
        }
    }
}
