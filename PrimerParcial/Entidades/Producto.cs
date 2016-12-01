using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Producto
    {
        protected int _codigoBarra;
        protected EMarcaProducto _marca;
        protected float _precio;

        public EMarcaProducto Marca
        {
            get { return this._marca; }
        }
        public float Precio
        {
            get { return this._precio; }
        }

        public Producto(int codigo, EMarcaProducto marca, float precio)
        {
            this._codigoBarra = codigo;
            this._marca = marca;
            this._precio = precio;
        }

        protected static string MostrarProducto(Producto prod)
        {
            return "MUESTRO PRODUCTO";
        }

        public static bool operator ==(Producto prodUno, Producto prodDos)
        {
            if ((prodUno == prodDos.Marca) && ((int)prodUno == (int)prodDos))
                return true;
            return false;
        }

        public static bool operator !=(Producto prodUno, Producto prodDos)
        {
            return !(prodUno == prodDos);
        }

        public static bool operator ==(Producto prodUno, EMarcaProducto marca)
        {
            if (prodUno.Marca == marca)
                return true;
            return false;
        }

        public static bool operator !=(Producto prodUno, EMarcaProducto marca)
        {
            return !(prodUno == marca);
        }

        public static explicit operator int(Producto prod)
        {
            return prod._codigoBarra;
        }
    }
}
