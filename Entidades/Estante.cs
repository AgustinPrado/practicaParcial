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

        #region PROPIEDADES
        public float ValorEstanteTotal
        {
            get
            {
                return this.GetValorEstante();
            }
        }
        #endregion

        #region CONSTRUCTORES
        private Estante()
        {
            this._productos = new List<Producto>();
        }

        public Estante(sbyte capacidad)
            : this()
        {
            this._capacidad = capacidad;
        }
        #endregion

        public List<Producto> GetProductos()
        {
            return this._productos;
        }

        public float GetValorEstante(ETipoProducto tipo)
        {
            float valor = 0;
            foreach (Producto item in this.GetProductos())
            {
                switch (tipo)
                {
                    case ETipoProducto.Galletita:
                        if (item is Galletita)
                            valor += item.Precio;
                        break;
                    case ETipoProducto.Gaseosa:
                        if (item is Gaseosa)
                            valor += item.Precio;
                        break;
                    case ETipoProducto.Jugo:
                        if (item is Jugo)
                            valor += item.Precio;
                        break;
                    case ETipoProducto.Todos:
                        valor += item.Precio;
                        break;
                    default:
                        break;
                }
            }
            return valor;
        }

        private float GetValorEstante()
        {
            return this.GetValorEstante(ETipoProducto.Todos);
        }

        public static string MostrarEstante(Estante est)
        {
            Galletita auxGalletita;
            Gaseosa auxGaseosa;
            Jugo auxJugo;

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Contenido estante:");
            sb.AppendLine("Capacidad: " + est._capacidad);
            sb.AppendLine("Listado de productos:");

            foreach (Producto item in est.GetProductos())
            {
                if(item is Galletita)
                {
                    auxGalletita = (Galletita)item;
                    sb.AppendLine(Galletita.MostrarGalletita(auxGalletita));
                }
                else if (item is Gaseosa)
                {
                    auxGaseosa = (Gaseosa)item;
                    sb.AppendLine(auxGaseosa.MostrarGaseosa());
                }
                else if(item is Jugo)
                {
                    auxJugo = (Jugo)item;
                    sb.AppendLine(auxJugo.MostrarJugo());
                }
            }
            return sb.ToString();
        }

        #region SOBRECARGA DE OPERADORES
        public static bool operator ==(Estante est, Producto prod)
        {
            foreach (Producto item in est.GetProductos())
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
            if(est._capacidad > est.GetProductos().Count)
            {
                if(est != prod)
                {
                    est.GetProductos().Add(prod);
                    return true;
                }
            }
            return false;
        }

        public static Estante operator -(Estante est, Producto prod)
        {
            if(est == prod)
            {
                est.GetProductos().Remove(prod);
            }
            return est;
        }

        public static Estante operator -(Estante est, ETipoProducto tipo)
        {
            for (int i = 0; i < est.GetProductos().Count; i++)
            {
                switch (tipo)
                {
                    case ETipoProducto.Galletita:
                        if (est.GetProductos()[i] is Galletita)
                        {
                            est -= est.GetProductos()[i];
                            // Corrije el problema de que se achique la colección.
                            i--;
                        }  
                        break;
                    case ETipoProducto.Gaseosa:
                        if (est.GetProductos()[i] is Gaseosa)
                        {
                            est -= est.GetProductos()[i];
                            // Corrije el problema de que se achique la colección.
                            i--;
                        }
                        break;
                    case ETipoProducto.Jugo:
                        if (est.GetProductos()[i] is Jugo)
                        {
                            est -= est.GetProductos()[i];
                            // Corrije el problema de que se achique la colección.
                            i--;
                        }
                        break;
                    case ETipoProducto.Todos:
                        est.GetProductos().Clear();
                        break;
                    default:
                        break;
                }
            }
            return est;            
        }
        #endregion
    }
}
